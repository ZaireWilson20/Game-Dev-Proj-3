using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp_Controller : MonoBehaviour {

    [SerializeField]
    private bool E_Pick = false;
    private bool pickExists = false;

    [SerializeField]
    private Transform pickUpText;

    private GameObject pickUpTextObj; 

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
	}

    public void showPickUp()
    {
        E_Pick = true; 
    }

    public void hidePickUp()
    {
        E_Pick = false; 
    }
}
