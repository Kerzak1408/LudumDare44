using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool aiMode = true;

    public GameObject LocalPlayer;

    public GameObject EndGamePanel;

    private List<PlayerControllerAi> aiPlayers;

	void Start ()
    {
        if (Scenes.ObjParams != null && Scenes.ObjParams.ContainsKey("ai"))
        {
            aiMode = (bool)Scenes.GetObjParam("ai");
        }    

        if (aiMode)
        {
            LocalPlayer.GetComponent<PlayerController>().GameManager = this;
            aiPlayers = new List<PlayerControllerAi>();
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
            var aiScript = aiPlayer.GetComponent<PlayerControllerAi>();
            aiScript.GameManager = this;
            aiPlayers.Add(aiScript);
        }
    }

    private float RandomCoordinate()
    {
        return UnityEngine.Random.Range(-13, 13);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GameOver(string message)
    {
        this.EndGamePanel.SetActive(true);
        this.EndGamePanel.GetComponentInChildren<Text>().text = message;
    }

    public void ReportKilled(PlayerControllerAi playerControllerAi)
    {
        aiPlayers.Remove(playerControllerAi);
        if (aiPlayers.Count == 0)
        {
            this.EndGamePanel.SetActive(true);
            this.EndGamePanel.GetComponentInChildren<Text>().text = "You won. :)";
        }
    }

    public void GoToMenu()
    {
        Scenes.Load("MenuScene");
    }

    public void Restart()
    {
        Scenes.Load("MainScene", Scenes.Parameters, Scenes.ObjParams);
    }
}
