using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TerrainGenerator : MonoBehaviour {
	public int GridSize = 10;
	public GameObject[] TerrainObjects;
	public GameObject WalkableTerrainHolder;
	public int NavMeshGenerationCalls = 0;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		GameManager.Log("Creating Grid");
		GenerateGrid();
		GameManager.Log("Creating Grid -> SUCCESS",GameManager.LogTier.Success);
		//GameManager._EnableDynamicNavMeshGeneration = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GenerateGrid(){
		List<int> WalkableTerrain = FindWalkableTerrain();
		WalkableTerrainHolder =  Instantiate(new GameObject("WalkableTerrainHolder"),new Vector3(0,0,0),Quaternion.identity);
		for(int i = 0; i < GridSize; i++){
			for(int j = 0; j < GridSize; j++){
				int ObjectID = Random.Range(0,TerrainObjects.Length);
				GameObject InstantiedObject = Instantiate(TerrainObjects[ObjectID],new Vector3(i,0,j),Quaternion.identity);
				if(WalkableTerrain.Contains(ObjectID))
					InstantiedObject.transform.parent = WalkableTerrainHolder.transform;
			}
		}
		WalkableTerrainHolder.AddComponent<NavMeshSurface>();
		WalkableTerrainHolder.GetComponent<NavMeshSurface>().collectObjects = CollectObjects.Children;
		RegenerateNavMesh();
		SpawnPlayer();
	}
	List<int> FindWalkableTerrain(){
		List<int> WalkableTerrain = new List<int>();
		for(int i = 0; i < TerrainObjects.Length;i++){
			if(TerrainObjects[i].GetComponent<TerrainPropertiesHolder>().TerrainCharacteristic.Walkable)
				WalkableTerrain.Add(i);
		}
		return WalkableTerrain;
	}
	public void RegenerateNavMesh(){
		WalkableTerrainHolder.GetComponent<NavMeshSurface>().BuildNavMesh();
		NavMeshGenerationCalls++;
	}
	public void SpawnPlayer(){
		Instantiate(Player,WalkableTerrainHolder.transform.GetChild(Random.Range(0,WalkableTerrainHolder.transform.childCount-1)).transform.position,Quaternion.identity);
	}
}
