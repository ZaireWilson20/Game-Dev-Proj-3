﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAction : MonoBehaviour {

    private Vector3 playerVelocity = Vector3.zero;
    private Vector3 playerRotation = Vector3.zero; 

    private Rigidbody rigid; 
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        MakeMove();
        MakeRotation(); 
    }

    public void Move(Vector3 _velocity)
    {
        playerVelocity = _velocity; 
    }

    public void Rotate(Vector3 _rotation)
    {
        playerRotation = _rotation;
    }

    void MakeMove()
    {
        //Move if player wants to move
        if(playerVelocity != Vector3.zero)
        {
            rigid.MovePosition(transform.position + playerVelocity * Time.deltaTime);
        }
    }

    void MakeRotation()
    {
        rigid.MoveRotation(transform.rotation * Quaternion.Euler(playerRotation) );
    }
}
