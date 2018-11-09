using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkTrigger : MonoBehaviour {
    public Dialogue[] allDialogue;
    
    public GameObject box;
    private Dialogue currentDia;
    private int currentSent = 0;

    public void triggerThat()
    {
        currentSent = FindObjectOfType<DialogueSystem>().getCurrentSentence();
        FindObjectOfType<DialogueSystem>().DisplayNextSentence(currentSent + 1);
        
    }

    public void StartTalkin()
    {
        FindObjectOfType<DialogueSystem>().StartDialogue(currentDia);      
    }

    public void lookForDialogue(string name)
    {
        for(int i = 0; i < allDialogue.Length; i++)
        {
            if(allDialogue[i].name == name)
            {
                Debug.Log("uhiuhiuhiu");
                currentDia = allDialogue[i];
               
                return;
            }
        }
    }

    public void nextSentence(int repNum)
    {
        Debug.Log("repNUM:  " + repNum);
        DialogueSystem temp = FindObjectOfType<DialogueSystem>();
        
        //Debug.Log(temp.GetSentences()[temp.getCurrentSentence()].responseList[repNum - 1].response);
        temp.DisplayNextSentence(temp.GetSentences()[temp.getCurrentSentence()].responseList[repNum - 1].nextSentenceID - 1);
        box.GetComponent<DialogueSystem>().currentResUI.SetActive(false);
        
        
        
    }
}
