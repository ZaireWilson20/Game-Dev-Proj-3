using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour {

    private RaycastHit look;
    private PopUp_Controller canScript;
    private GameObject canvas; 
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        canScript = canvas.GetComponent<PopUp_Controller>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pick Up Item")
        {
            canScript.showPickUp();
        }
    }
}
