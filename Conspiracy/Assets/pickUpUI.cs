using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpUI : MonoBehaviour {

    private PopUp_Controller canScript;
    private GameObject canvas;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Main Canvas");
        canScript = canvas.GetComponent<PopUp_Controller>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerInfo = other.GetComponent<PlayerController>();
        if (other.CompareTag("Player"))
        {
            if (playerInfo.facingTrigger())
            {
                Debug.Log("yeee");
            }
            canScript.showPickUp(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canScript.hidePickUp();
        }
    }
}
