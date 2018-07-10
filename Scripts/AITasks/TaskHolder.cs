using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaskHolder : MonoBehaviour {
	public TaskManager.TaskType Task;
	public TaskManager.MinionProperties Properties;
	// Use this for initialization
	void Start () {
		Properties.WorkStatus = TaskManager.TaskListEnum.Idle;
		}
	
	// Update is called once per frame
	void Update () {
		print(ResourceHolder.PlayersResources[0].Ore);
		if(Task.TaskList == TaskManager.TaskListEnum.Mine){
			if(Task.Destination != null){
				gameObject.GetComponent<NavMeshAgent>().SetDestination(Task.Destination.position);
			}else{
				Task.TaskList = TaskManager.TaskListEnum.Idle;
			}
			Properties.WorkStatus = TaskManager.TaskListEnum.Mine;
		}
	}
	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.gameObject.transform == Task.Destination){
			collisionInfo.gameObject.GetComponent<TerrainPropertiesHolder>().ChangeTerrain(TerrainProperties.TerrainOpertations.Mine);
			Properties.WorkStatus = TaskManager.TaskListEnum.Idle;
			ResourceHolder.PlayersResources[Properties.PlayerID].Ore++;
			Task.TaskList = TaskManager.TaskListEnum.Idle;
			Properties.WorkStatus = TaskManager.TaskListEnum.Idle;
		}
	}
}
