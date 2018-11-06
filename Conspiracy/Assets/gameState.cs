using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gameState : MonoBehaviour {
    public enum state {
        Pause,
        Dialogue, 
        FreeRoam
    };

    [SerializeField]
    private Camera mainCamera; 
    public state currentState; 
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pauseGame()
    {
        currentState = state.Pause; 
    }

    public void resumeGame()
    {
        currentState = state.FreeRoam; 
    }

    public void startDialogue()
    {
        currentState = state.Dialogue; 
        
    }

}
