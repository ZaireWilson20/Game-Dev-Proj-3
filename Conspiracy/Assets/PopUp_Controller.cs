using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp_Controller : MonoBehaviour {

    [SerializeField]
    private bool E_Pick = false;
    private bool pickExists = false;
    private bool diaExists = false;
    private bool talkUI = false; 
    [SerializeField]
    private bool diaUp; 

    [SerializeField]
    private GameObject pickUpText;
    [SerializeField]
    private GameObject dialougeUI;


    private GameObject pickUpTextObj;

    
    private GameObject diaObject;

    private DialogueSystem dialogue;

    [SerializeField]
    private GameObject diaPanel; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Creating Prompt for dialogue interaction
        nameLater(pickUpText, ref pickUpTextObj, ref E_Pick, ref pickExists);

        //Starting Dialogue Scene
        nameLater(dialougeUI, ref diaObject, ref diaUp, ref diaExists);
        
	}

    private void nameLater(GameObject ogObject, ref GameObject cloneObj, ref bool inRange, ref bool exists)
    {
        if (inRange && !exists)
        {

            cloneObj = Instantiate(ogObject, transform, false);
            exists = true;
        }
        else if (!inRange && exists)
        {
            //pickUpTextObj = GameObject.FindGameObjectWithTag("Pick Up");
            Destroy(cloneObj);
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

    public void showTalk()
    {
        talkUI = true;
    }

    public void hideTalk()
    {
        talkUI = false;
    }

    public void showDialogue()
    {
        diaUp = true; 
    }

    public void hideDialogue()
    {
        diaUp = false;
    }
}
