using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public GameObject Canvas;
	// Use this for initialization
	void Start () {
		Canvas = GameObject.FindGameObjectWithTag("UIElement");	
	}
	
	// Update is called once per frame
	void Update () {
		Canvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Ore: " + ResourceHolder.PlayersResources[0].Ore.ToString();
	}
}
