using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp_Controller : MonoBehaviour {

    [SerializeField]
    private bool E_Pick = false;
    private bool pickExists = false;
    private bool diaExists = false; 
    private bool diaUp; 

    [SerializeField]
    private Transform pickUpText;
    [SerializeField]
    private GameObject dialougeUI;


    private GameObject pickUpTextObj;
    private GameObject diaObject; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (E_Pick && !pickExists)
        {
            Instantiate(pickUpText, transform, false);
            pickExists = true; 
        }
        else if(!E_Pick)
        {
            pickUpTextObj = GameObject.FindGameObjectWithTag("Pick Up");
            Destroy(pickUpTextObj);
            pickExists = false; 
        }

        if (diaUp && !diaExists)
        {
            //Run Dialogue
            Instantiate(dialougeUI, transform, false);
            diaExists = true; 

        }
        else if (!diaUp)
        {
            diaObject = GameObject.FindGameObjectWithTag("Dialogue Canvas");
            Destroy(diaObject);
            diaExists = false; 
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

    public void showDialogue()
    {
        diaUp = true; 
    }

    public void hideDialogue()
    {
        diaUp = false;
    }
}
