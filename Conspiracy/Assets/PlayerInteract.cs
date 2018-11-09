using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour {

    private RaycastHit look;
    private PopUp_Controller canScript;
    private GameObject canvas;
    private bool canTalk = false;
    public bool talking = false;
    private PlayerController anonCont;
    private DialogueContainer blah;
    public string npcInView = "";

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
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            talking = true;
            canTalk = false;
            canScript.showDialogue();
            canScript.hidePickUp();
        
        }

        else if (talking && Input.GetKeyDown(KeyCode.E))
        {
            canScript.hideDialogue();
            anonCont.setSpeaking(false);
            talking = false; 
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Npc")
        {
            npcInView = other.name;
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
