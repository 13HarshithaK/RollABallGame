using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public GameObject Player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	//for follow camera, last known states etc late update is used, like update but runs after all frames 
	void LateUpdate () {
		transform.position = Player.transform.position + offset;
	}
}
