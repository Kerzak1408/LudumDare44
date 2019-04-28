using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : PlayerControllerBase
{
    public Camera MainCamera;
    public float speed = 5f;
    public Text TimeText;

    protected override void Start()
    {
        base.Start();
        Direction = Vector3.up;	
	}
	
	protected override void Update()
    {
        base.Update();

        int minutes = (int) SecondsLeft / 60;
        int seconds = (int) SecondsLeft - minutes * 60;
        string minutesString = minutes < 10 ? "0" + minutes : minutes.ToString();
        string secondsString = seconds < 10 ? "0" + seconds : seconds.ToString();
        this.TimeText.text = minutesString + ":" + secondsString;

#if UNITY_ANDROID && !UNITY_EDITOR
        foreach (var touch in Input.touches)
        {
            if (!IsPointOverUI(touch.position.x, touch.position.y))
            {
                MovePlayer(touch.position);
                break;
            }
        }
#else

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {            
            MovePlayer(Input.mousePosition);
        }
#endif
    }

    private void MovePlayer(Vector3 clickPosition)
    {
        clickPosition = MainCamera.ScreenToWorldPoint(clickPosition);
        clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
        Direction = transform.position - clickPosition;
        Direction = new Vector3(Direction.x, Direction.y, 0);
        Direction = Direction.normalized;

        var delta = Time.deltaTime * Direction * speed;
        var newPlayerPosition = this.transform.position + delta;

        this.transform.position = newPlayerPosition;
        MainCamera.transform.position = new Vector3(newPlayerPosition.x, newPlayerPosition.y, MainCamera.transform.position.z); ;

        var angleRadians = Mathf.Atan2(delta.x, delta.y);
        var eulerAngles = this.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, -Mathf.Rad2Deg * angleRadians);
    }
    
    private bool IsPointOverUI(float x, float y)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(x, y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
