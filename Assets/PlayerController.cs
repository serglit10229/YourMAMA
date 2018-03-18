﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire");
            GetComponentInChildren<AnimationController>().Fire = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("FireStop");
            GetComponentInChildren<AnimationController>().Fire = false;
        }

    }
}
