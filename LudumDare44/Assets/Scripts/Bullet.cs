using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float Speed = 20;

    private Vector3 direction;
    private bool shooting = false;
    private float timeToLive = 3;    

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        this.shooting = true;
    }

    public void Update()
    {
        if (shooting)
        {
            this.transform.position += direction * Time.deltaTime * Speed;
            this.timeToLive -= Time.deltaTime;
            if (timeToLive <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
