using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;
    public float speed = 5f;

	void Start()
    {
		
	}
	
	void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);

            var direction = mousePosition - transform.position;
            direction = direction.normalized;

            var delta = Time.deltaTime * direction * speed;
            this.transform.position += delta;
            MainCamera.transform.position += delta;

            var angleRadians = Mathf.Atan2(delta.x, delta.y);
            Debug.Log("Angle = " + angleRadians);
            var eulerAngles = this.transform.eulerAngles;
            this.transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, -Mathf.Rad2Deg * angleRadians);
        }
	}
}
