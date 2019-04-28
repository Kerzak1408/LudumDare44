﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // scene names
    public static readonly string LOGIN_SCENE = "Login";
    public static readonly string MAIN_MENU_SCENE = "MainMenu";
    public static readonly string TEAMS_MANAGEMENT_SCENE = "TeamsManagementScene";
    public static readonly string BATTLE_SCENE = "BattleScene";
    public static readonly string FRACTION_SCENE = "FractionScene";
    public static readonly string DRAFT_SCENE = "Draft";
    public static readonly string LOCAL_TRADE_SCENE = "LocalTradeScene";

    // scene param names
    public static readonly string TEAM_MANAGEMENT_STATE = "teamManagementState";
    public static readonly string BATTLE_TYPE = "battleType";
    public static readonly string GAME_MODE = "gameMode";
    public static readonly string PICK_MODE = "pickMode";
    public static readonly string AI_TYPE = "aiType";
    public static readonly string GAME_READY_MSG = "gameReadyMsg";
    public static readonly string DISCONNECTED = "disconnected";
    public static readonly string SERVER_DISCONNECT = "serverDisconnect";
    public static readonly string OFFERED_PLAYER_LOGIN = "offeredPlayerLogin";

    public static Dictionary<string, string> Parameters { get; private set; }
    public static Dictionary<string, object> ObjParams { get; private set; }

    /// <summary>
    /// Loads a scene with multiple parameters.
    /// </summary>
    /// <param name="sceneName">name of the scene to load</param>
    /// <param name="parameters">dictionary of scene string parameters</param>
    /// <param name="objParams">dictionary of scene object parameters</param>
    public static void Load(
        string sceneName,
        Dictionary<string, string> parameters = null,
        Dictionary<string, object> objParams = null
    )
    {
        Parameters = parameters;
        ObjParams = objParams;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Loads a scene with single string parameter.
    /// </summary>
    /// <param name="sceneName">name of the scene to load</param>
    /// <param name="paramKey">key of the parameter</param>
    /// <param name="paramValue">value of the parameter</param>
    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        Parameters = new Dictionary<string, string> { { paramKey, paramValue } };
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Loads a scene with single object parameter.
    /// </summary>
    /// <param name="sceneName">name of the scene to load</param>
    /// <param name="paramKey">key of the parameter</param>
    /// <param name="paramValue">value of the parameter</param>
    public static void Load(string sceneName, string paramKey, object paramValue)
    {
        ObjParams = new Dictionary<string, object> { { paramKey, paramValue } };
        SceneManager.LoadScene(sceneName);
    }

    /// <param name="paramKey">key of the parameter to get</param>
    /// <returns>value of the scene parameter</returns>
    public static string GetParam(string paramKey)
    {
        if (Parameters == null) return "";
        return Parameters[paramKey];
    }

    /// <param name="paramKey">key of the parameter to get</param>
    /// <param name="value">value of the scene parameter</param>
    /// <returns>true if scene was loaded with given parameter</returns>
    public static bool TryGetParam(string paramKey, out string value)
    {
        value = "";
        if (Parameters == null) return false;

        return Parameters.TryGetValue(paramKey, out value);
    }

    /// <param name="paramKey">key of the parameter to get</param>
    /// <returns>value of the scene parameter</returns>
    public static object GetObjParam(string paramKey)
    {
        if (ObjParams == null) return null;
        return ObjParams[paramKey];
    }

    /// <param name="paramKey">key of the parameter to get</param>
    /// <param name="value">value of the scene parameter</param>
    /// <returns>true if scene was loaded with given parameter</returns>
    public static bool TryGetObjParam(string paramKey, out object value)
    {
        value = null;
        if (ObjParams == null) return false;

        return ObjParams.TryGetValue(paramKey, out value);
    }

    /// <param name="paramKey">key of the parameter to get</param>
    /// <param name="value">value of the scene parameter</param>
    /// <returns>true if scene was loaded with given parameter</returns>
    public static bool TryGetGenericParam<T>(string paramKey, out T value)
    {
        value = default(T);
        if (ObjParams == null) return false;

        object result;
        if (ObjParams.TryGetValue(paramKey, out result) && result is T)
        {
            value = (T)result;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <param name="sceneName">name of the scene to check</param>
    /// <returns>true if given scene is currently active</returns>
    public static bool IsActive(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    /// <returns>name of the currently active scene</returns>
    public static string GetActive()
    {
        return SceneManager.GetActiveScene().name;
    }
}