using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour {

    private RaycastHit look;
    private PopUp_Controller canScript;
    private GameObject canvas;
    private bool canTalk = false;
    private bool talking = false; 
    [SerializeField]
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        canScript = canvas.GetComponent<PopUp_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            talking = true; 
            canScript.showDialogue();
        }

        if (talking && Input.GetKeyDown(KeyCode.E))
        {
            canScript.hideDialogue();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Npc")
        {
                Debug.Log("hi guy");
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
