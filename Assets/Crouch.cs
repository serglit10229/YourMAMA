using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {
	public CharacterController characterController;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftAlt))
		{
			characterController.height = 0.5f;
		}
		else
		{
			characterController.height = 1.8f;
		}
	}
}
