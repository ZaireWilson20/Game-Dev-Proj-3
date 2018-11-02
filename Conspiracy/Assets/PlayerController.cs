using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerAction))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float sensitivity = 3f; 

    private PlayerAction action;

	// Use this for initialization
	void Start () {
        action = GetComponent<PlayerAction>(); 	
	}
	
	// Update is called once per frame
	void Update () {

        //Getting Input 
        float _xMovement = Input.GetAxisRaw("Horizontal");
        float _yMovement = Input.GetAxisRaw("Vertical");

        //Individual movement vectors of horizontal and vertical directions
        Vector3 _moveHor = transform.right * _xMovement;
        Vector3 _moveVert = transform.forward * _yMovement;

        //Final movement vector normalized so that magnitude is dependent on speed
        Vector3 _velocity = (_moveHor + _moveVert).normalized * speed;

        //Move Player
        action.Move(_velocity);

        //Player Rotation
        float _turnRot = Input.GetAxis("Mouse X");

        Vector3 _rotation = new Vector3(0f, _turnRot, 0f) * sensitivity;

        action.Rotate(_rotation);

	}
}
