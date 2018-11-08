using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
    public Animator bookanim;
    public GameObject bookStuff; 
	// Use this for initialization
	void Start () {
        bookanim = bookStuff.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void bookOpen()
    {
        bookanim.SetBool("openBook", true);
    }
}
