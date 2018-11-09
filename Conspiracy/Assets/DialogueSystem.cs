using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour {

    //public Dialogue mainDialogue; 


    [SerializeField]
    private Queue<string> sentences;

    private Text currentText;
    private Text nameText;
    private GameObject textObject;
    private GameObject nameObject; 
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        //currentText = textObject.GetComponent<Text>();

        //nameText = nameObject.GetComponent<Text>();
        //nameText.text = name; 
        
    	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartDialogue(Dialogue allSentences)
    {
        nameText.text = allSentences.name;

        sentences.Clear();

        foreach (string sentence in allSentences.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        currentText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            currentText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        return;
    }
}
