using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour {
	[System.Serializable]
	public struct Resources{
		public int PlayerID;
		public int Ore;
	}
	public static Resources[] PlayersResources;
	// Use this for initialization
	void Start () {
		PlayersResources = new Resources[GameManager._GameSettings.NumberOfPlayers];
		for(int i = 0; i < PlayersResources.Length; i++){
			PlayersResources[i].PlayerID = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
