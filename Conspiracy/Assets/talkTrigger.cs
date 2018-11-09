using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTrigger : MonoBehaviour {

    [SerializeField]
    public Dialogue[] allDia;

    public GameObject pIn;
    private PlayerInteract plInteract; 
    public GameObject box;
    private string currentNpc;
    private int curId = -1; 
    private DialogueSystem diaSys; 

    void Start()
    {
        diaSys = box.GetComponent<DialogueSystem>();
    }


    private void getCurrentID()
    {
        for(int i = 0; i < allDia.Length; i++)
        {
            if(currentNpc == allDia[i].name)
            {
                curId = i;
                return;
            }
        }
    }
     
    public void triggerThat()
    {
        pIn = GameObject.FindGameObjectWithTag("Interact");
        plInteract = pIn.GetComponent<PlayerInteract>();
        currentNpc = plInteract.npcInView;
        getCurrentID();
        diaSys.StartDialogue(allDia[curId]); 
    }


    public void setDiaObj(GameObject obj)
    {
        obj = gameObject;
    }
}
