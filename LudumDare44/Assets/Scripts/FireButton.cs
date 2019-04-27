using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour {

    public Image Image;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        Image.alphaHitTestMinimumThreshold = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        var bulletObject = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
        bulletObject.transform.position = player.transform.position;
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.Shoot(player.Direction, player);
    }
}
