using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewHandler : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool facingTrigger()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            
            if (hit.transform.tag == "Npc")
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.yellow, 1000f);

                return true;
            }
        }


        return false;
    }
}
