﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

    CharacterController cc;
	// Use this for initialization

	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().Play();
        if (cc.velocity.magnitude > 2f &&
            GetComponent<AudioSource>().isPlaying == false) {
            GetComponent<AudioSource>().Play();
        }
	}
}
