using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerAction))]

public class PlayerController : MonoBehaviour {

    private enum gameStates { };

    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float sensitivity = 3f; 

    private PlayerAction action;
    private gameState stateScript; 

    private GameObject state;
    [SerializeField]
    private Camera playerCamera;


    [SerializeField]
    private PlayerInteract _playerState;
    [SerializeField]
    private GameObject _interactObj;

    public bool speaking = false; 
	// Use this for initialization
	void Start () {
        action = GetComponent<PlayerAction>();
        state = GameObject.FindGameObjectWithTag("GameState");
        stateScript = state.GetComponent<gameState>();
        _playerState = _interactObj.GetComponent<PlayerInteract>();
	}
	
	// Update is called once per frame
	void Update () {

        
        if (_playerState.talking)
        {
            if (!speaking)
            {
                setSpeaking(true);
            }
        }
        else { 
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
            float _turnRot = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float _turnVert = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            Vector3 _rotation = new Vector3(0f, _turnRot, 0f) ;

            action.Rotate(_rotation);
            playerCamera.transform.Rotate(Vector3.left * _turnVert);
        }


    }

    public bool facingTrigger()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f )) 
        {
            Debug.DrawRay(transform.position, Vector3.forward, Color.yellow, 1000f);
            if (hit.transform.tag == "Npc")
            {


                Debug.Log("Did Hit");
                return true; 
            }
        }


        return false; 
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public void setSpeaking(bool state)
    {
        speaking = state; 
    }

}
