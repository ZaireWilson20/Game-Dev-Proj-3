using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour {

    private PopUp_Controller canScript;
    private GameObject canvas;
    private GameObject gStateObject;
    private gameState gStateScript;
    private bool inRange = false;
    bool currentlyTalking;


    [SerializeField]
    private GameObject playerCamera;
    private viewHandler pView;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        gStateObject = GameObject.FindGameObjectWithTag("GameState");
        canScript = canvas.GetComponent<PopUp_Controller>();
        gStateScript = gStateObject.GetComponent<gameState>();

        //Script for Camera Handling
        pView = playerCamera.GetComponent<viewHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyTalking && Input.GetKeyDown(KeyCode.E))
        {
            gStateScript.resumeGame(); 
        }
        else if (inRange && Input.GetKeyDown(KeyCode.E) && pView.facingTrigger())
        {
            gStateScript.currentState = gameState.state.Dialogue;
            Debug.Log("bitchh");
            currentlyTalking = true; 
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        canScript.showPickUp();
        if (other.CompareTag("Player"))
        {
            Debug.Log("son");
            currentlyTalking = false; 
            inRange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canScript.hidePickUp();
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
