using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainProperties : MonoBehaviour {
	[System.Serializable]
	public struct TerrainCharacteristic{
		public bool Walkable;
		public bool Mineable;
		public List<TerrainEvolution> TerrainLevels;
	}
	[System.Serializable]
	public struct TerrainEvolution{
		public TerrainOpertations Operation;
		public GameObject LevelObject;
	}
	public enum TerrainOpertations{
		Mine
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
