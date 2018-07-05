using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private Vector3 MoveToPosition;
	// Use this for initialization
	void Start () {
		MoveToPosition = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager._GameState == GameManager.GameStates.Game){
			Transform CameraTransfrom = Camera.main.transform;
			if(Input.GetKey(GameManager._KeyBindsSettings.Up)){
				MoveToPosition += new Vector3(0,0,GameManager._GameSettings.MapScrollSpeed);
			}
			if(Input.GetKey(GameManager._KeyBindsSettings.Left)){
				MoveToPosition += new Vector3(-GameManager._GameSettings.MapScrollSpeed,0,0);
			}
			if(Input.GetKey(GameManager._KeyBindsSettings.Right)){
				MoveToPosition += new Vector3(GameManager._GameSettings.MapScrollSpeed,0,0);
			}
			if(Input.GetKey(GameManager._KeyBindsSettings.Down)){
				MoveToPosition += new Vector3(0,0,-GameManager._GameSettings.MapScrollSpeed);
			}
			CameraTransfrom.position = Vector3.MoveTowards(CameraTransfrom.position,MoveToPosition,Mathf.Sqrt(Vector3.Distance(CameraTransfrom.position,MoveToPosition)*0.008f));
		}
	}
}
