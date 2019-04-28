using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerControllerAi : PlayerControllerBase
{
    public float speed = 5f;

    private float timeout = 0f;

    public GameManager GameManager;

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
        ConsiderShooting();
    }

    private void ConsiderShooting()
    {
        //if (UnityEngine.Random.value < Time.deltaTime)
        {
            var ray = new Ray(transform.position, Direction);
            var hits = Physics.RaycastAll(ray, 4);
            if (hits.Any(hit => hit.transform.gameObject.GetComponent<PlayerControllerBase>() != null))
            {
                Shoot();
            }
        }
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

    public override void OnKill()
    {
        GameManager.ReportKilled(this);
        base.OnKill();
    }
}
