using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static bool _EnableDeveloperLogs;
	public bool EnableDeveloperLogs = true;
	public static GameObject _ScriptHolder;
	public enum LogTier{
		Log,Success,Fail,Warning,Error
	};
	[System.Serializable]
	public struct KeyBinds{
		public KeyCode Up;
		public KeyCode Down;
		public KeyCode Left;
		public KeyCode Right;
		public int ClickRight; //0 left,1 right, 2 middle
	}
	public static KeyBinds _KeyBindsSettings;
	[System.Serializable]
	public struct GameSettingsStruct{
		public float MapScrollSpeed;
	}
	public static GameSettingsStruct _GameSettings;
	public GameSettingsStruct GameSettings;
	public KeyBinds KeyBindsSettings;
	public enum GameStates{
		Game
	};
	public static GameStates _GameState;
	public static bool _EnableDynamicNavMeshGeneration;

	// Use this for initialization
	void Start () {
		_EnableDynamicNavMeshGeneration = false;
		_EnableDeveloperLogs = EnableDeveloperLogs;
		_KeyBindsSettings = KeyBindsSettings;
		_GameSettings = GameSettings;
		_GameState = GameStates.Game;
		_ScriptHolder = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public static void Log(string Message, LogTier Tier = LogTier.Log){
		if(_EnableDeveloperLogs == false)
			return;
		switch(Tier){
			case LogTier.Success:
				Debug.Log("<color=green>"+Message+"</color>");
				break;
			case LogTier.Fail:
				Debug.Log("<color=red>"+Message+"</color>");
				break;
			case LogTier.Warning:
				Debug.LogWarning(Message);
				break;
			case LogTier.Error:
				Debug.LogError(Message);
				break;
			default:
				Debug.Log(Message);
				break;
		}
	}
}
