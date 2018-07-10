using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDynamicNavMeshGeneration : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameManager._EnableDynamicNavMeshGeneration = true;
		Destroy(gameObject.GetComponent<EnableDynamicNavMeshGeneration>());
	}
}
