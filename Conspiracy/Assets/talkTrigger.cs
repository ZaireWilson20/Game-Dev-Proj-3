using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTrigger : MonoBehaviour {
    public Dialogue npcDia;
    public GameObject box; 

   

    public void triggerThat()
    {
        Debug.Log(npcDia.name);
        FindObjectOfType<DialogueSystem>().StartDialogue(npcDia); 
    }
}
