using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunctionality : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager._GameState == GameManager.GameStates.Game){
			if(Input.GetMouseButtonUp(GameManager._KeyBindsSettings.ClickRight)){
				RaycastHit Hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        		if (Physics.Raycast(ray,out Hit, Mathf.Infinity))
            		if(Hit.transform.gameObject.GetComponent<TerrainPropertiesHolder>().TerrainCharacteristic.Mineable){
						TaskManager.TaskType Task;
						Task.Destination = Hit.transform;
						Task.TaskList = TaskManager.TaskListEnum.Mine;
						Task.PlayerID = 0;
						TaskManager.TaskQueue.Add(Task);
					}
				}
		}
	}
}
