using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static bool _EnableDeveloperLogs;
	public bool EnableDeveloperLogs = true;
	public enum LogTier{
		Log,Success,Fail,Warning,Error
	};
	// Use this for initialization
	void Start () {
		_EnableDeveloperLogs = EnableDeveloperLogs;
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
