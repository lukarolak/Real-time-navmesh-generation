using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
	public enum TaskListEnum{
		Mine
	}
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
		
	}
}
