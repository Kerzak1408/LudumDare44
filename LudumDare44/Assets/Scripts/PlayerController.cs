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

            this.transform.position += Time.deltaTime * direction * speed;
        }
	}
}
