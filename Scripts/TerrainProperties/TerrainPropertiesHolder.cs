using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TerrainPropertiesHolder : MonoBehaviour {

	public TerrainProperties.TerrainCharacteristic TerrainCharacteristic;
	// Use this for initialization
	void Start () {
		if(TerrainCharacteristic.Walkable == true && GameManager._EnableDynamicNavMeshGeneration){
			gameObject.transform.parent = GameManager._ScriptHolder.GetComponent<TerrainGenerator>().WalkableTerrainHolder.transform;
			GameManager._ScriptHolder.GetComponent<TerrainGenerator>().RegenerateNavMesh();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeTerrain(TerrainProperties.TerrainOpertations Operation){
		foreach(TerrainProperties.TerrainEvolution TerrainInfo in TerrainCharacteristic.TerrainLevels){
			if(TerrainInfo.Operation == Operation){
				Instantiate(TerrainInfo.LevelObject,gameObject.transform.position,Quaternion.identity);
				if(TerrainInfo.ParticleEffect != null)
					Instantiate(TerrainInfo.ParticleEffect,gameObject.transform.position,Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}
