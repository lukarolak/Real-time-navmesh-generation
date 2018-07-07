using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaskHolder : MonoBehaviour {
	public TaskManager.TaskType Task;
	// Use this for initialization
	void Start () {
		Task.TaskList = TaskManager.TaskListEnum.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		if(Task.TaskList != TaskManager.TaskListEnum.Idle){
			if(Task.Destination != null)
				gameObject.GetComponent<NavMeshAgent>().SetDestination(Task.Destination.position);
		}
		if(Task.Destination == null){
			Task.TaskList = TaskManager.TaskListEnum.Idle;
			gameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
		}
	}
	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.gameObject.transform == Task.Destination){
			collisionInfo.gameObject.GetComponent<TerrainPropertiesHolder>().ChangeTerrain(TerrainProperties.TerrainOpertations.Mine);
			Task.TaskList = TaskManager.TaskListEnum.Idle;
		}
	}
}
