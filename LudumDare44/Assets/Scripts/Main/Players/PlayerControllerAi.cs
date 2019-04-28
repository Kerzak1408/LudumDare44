using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAi : PlayerControllerBase
{
    public float speed = 5f;

    private float timeout = 0f;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        ChangeDirection();
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
        ChangeDirection();
        MovePlayer();
    }

    private void ChangeDirection()
    {
        while (Direction == Vector3.zero || Physics.Raycast(new Ray(transform.position, Direction), 2))
        {
            Direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        }
        
    }

    private void MovePlayer()
    {
        var delta = Time.deltaTime * Direction * speed;
        this.transform.position += delta;
        var angleRadians = Mathf.Atan2(delta.x, delta.y);
        var eulerAngles = this.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, -Mathf.Rad2Deg * angleRadians);
    }
}
