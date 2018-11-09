using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp_Controller : MonoBehaviour {

    [SerializeField]
    private bool E_Pick = false;
    private bool pickExists = false;
    private bool diaExists = false;
    private bool talkUI = false; 
    private string npcName; 
    [SerializeField]
    private bool diaUp; 

    [SerializeField]
    public GameObject pickUpText;
    [SerializeField]
    public GameObject dialougeUI;


    private GameObject pickUpTextObj;

    
    private GameObject diaObject;

    private DialogueSystem dialogue;

    [SerializeField]
    private GameObject diaPanel;

    private bool diaInst = false;
    private bool first = false;
    private talkTrigger trigger;
    public GameObject triggerObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Creating Prompt for dialogue interaction
        nameLater(pickUpText, ref E_Pick, ref pickExists, false);

        //Starting Dialogue Scene
        nameLater(dialougeUI, ref diaUp, ref diaExists, true);
        
	}

    private void nameLater(GameObject ogObject, ref bool inRange, ref bool exists, bool isDia)
    {
        if (diaInst)
        {
            trigger = triggerObj.GetComponent<talkTrigger>();
            trigger.lookForDialogue(npcName);
            trigger.StartTalkin();

                diaInst = false;
            
        }
        
        if (inRange && !exists)
        {

            ogObject.SetActive(true);
            exists = true;
            if (isDia)
            {
                diaInst = true;
            }
        }
        else if (!inRange && exists)
        {
            //pickUpTextObj = GameObject.FindGameObjectWithTag("Pick Up");
            ogObject.SetActive(false);
            exists = false;
        }
    }

    public void showPickUp()
    {
        E_Pick = true; 
    }

    public void hidePickUp()
    {
        E_Pick = false; 
    }

    public void showTalk(string name)
    {
        
        talkUI = true;
    }

    public void hideTalk()
    {
        talkUI = false;
    }

    public void showDialogue(string name)
    {
        npcName = name;
        diaUp = true; 
    }

    public void hideDialogue()
    {
        diaUp = false;
    }
}
