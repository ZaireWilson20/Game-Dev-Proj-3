using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddResponseText : MonoBehaviour {

    public Text[] resText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addText(Response[] responses)
    {
        for (int i = 0; i < responses.Length; i++)
        {
            resText[i].text = responses[i].response;
        }
    }
}
