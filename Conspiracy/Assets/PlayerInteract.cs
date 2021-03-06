﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour {

    private RaycastHit look;
    private PopUp_Controller canScript;
    private GameObject canvas;
    private bool canTalk = false;
    public bool talking = false;
    private PlayerController anonCont;

    public GameObject talkTObj; 
    private DialogueSystem talkT;
    private bool lookForTalk = false;
    private bool convoEnd = false;
    private bool talkTExists = false;
    private string npcName;
    [SerializeField]

    public GameObject thisCont; 
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        anonCont = thisCont.GetComponent<PlayerController>();
        canScript = canvas.GetComponent<PopUp_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lookForTalk)
        {
            talkT = GameObject.FindGameObjectWithTag("Dialogue Canvas").GetComponent<DialogueSystem>();
            talkTExists = true;  
            lookForTalk = false;
        }

        if (talkTExists)
        {
            //Debug.Log(talkT.currentSentence);
            convoEnd = talkT.End();
        }
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            talking = true;
            canTalk = false;
            canScript.showDialogue(npcName);
            canScript.hidePickUp();
            lookForTalk = true; 
        }

        else if (talking && (Input.GetKeyDown(KeyCode.E) || convoEnd))
        {
            Debug.Log(talkTExists);
            canScript.hideDialogue();
            anonCont.setSpeaking(false);
            talking = false;
            talkT.isEnd = false;
            convoEnd = false;
            talkTExists = false; 
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Npc")
        {
            npcName = other.name;
                canScript.showPickUp();
            canTalk = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            canScript.hidePickUp();
            canTalk = false; 
        }
    }

}
