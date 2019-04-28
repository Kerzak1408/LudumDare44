using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool aiMode = true;

	void Start ()
    {
        if (Scenes.ObjParams != null && Scenes.ObjParams.ContainsKey("ai"))
        {
            aiMode = (bool)Scenes.GetObjParam("ai");
        }    

        if (aiMode)
        {
            LoadAiGame();
        }
        else
        {

        }
	}

    private void LoadAiGame()
    {
        for (int i = 0; i < 4; i++)
        {
            var aiPlayer = Instantiate(Resources.Load("Prefabs/AiPlayer")) as GameObject;
            aiPlayer.transform.position = new Vector3(RandomCoordinate(), RandomCoordinate(), 1);
        }
    }

    private float RandomCoordinate()
    {
        return UnityEngine.Random.Range(-13, 13);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
