using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TaskManager : MonoBehaviour {
	public enum TaskListEnum{
		Mine, Idle
	}
	[System.Serializable]
	public struct TaskType{
		public TaskListEnum TaskList;
		public Transform Destination;
	}
	public static List<TaskType> TaskQueue = new List<TaskType>();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(TaskQueue.Count>0){
			if(TaskQueue[0].TaskList == TaskListEnum.Mine){
				GameObject[] Miners = GameObject.FindGameObjectsWithTag("Miner");
				foreach(GameObject Miner in Miners){
					if(Miner.GetComponent<TaskHolder>().Task.TaskList == TaskListEnum.Idle){
						Miner.GetComponent<TaskHolder>().Task = TaskQueue[0];
						TaskQueue.RemoveAt(0);
						break;
					}
				}
				print("LeftTasks"+TaskQueue.Count.ToString());
			}
		}
	}
}
