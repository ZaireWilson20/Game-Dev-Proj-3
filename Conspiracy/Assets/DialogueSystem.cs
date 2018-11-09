using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour {

    //public Dialogue mainDialogue; 

    public Transform main_canvas;
    [SerializeField]
    private Sentence[] sentences;
    public GameObject[] responseUI;
    private Text currentText;
    private Text nameText;
    public GameObject textObject;
    public GameObject nameObject;
    public int currentSentence = 0;
    public bool isEnd = false;
    public bool responseMode = false;
    public GameObject currentResUI; 
    public GameObject canvas;
    private bool exit;
    public AddResponseText addRes;
    

    private void Awake()
    {
        currentText = textObject.GetComponent<Text>();
        main_canvas = GameObject.FindGameObjectWithTag("Main Canvas").transform;
        nameText = nameObject.GetComponent<Text>();
        nameText.text = name;
    }

    // Use this for initialization
    void Start() {
       
        Debug.Log("JII");
    }

    // Update is called once per frame
    void Update() {

    }


    public void StartDialogue(Dialogue allSentences)
    {
        Debug.Log(nameText);
        nameText.text = allSentences.name;
        sentences = allSentences.sentences;


        DisplayNextSentence(currentSentence);
    }

    public void DisplayNextSentence(int curSent)
    {
        currentSentence = curSent;
        if (exit)
        {
            currentSentence = 0;
            EndDialogue();
            exit = false;
        }



        string sentence = sentences[curSent].sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        if (sentences[currentSentence].isQuestion)
        {
            responseMode = true;
            DisplayResponses(sentences[curSent].responseList.Length);
        }
        if (sentences[curSent].isEnd)
        {
            exit = true;
        }
        
        Debug.Log(currentSentence);
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
        isEnd = true;
        return;
    }

    public bool End()
    {
        return isEnd;
    }
    private void DisplayResponses(int numOfRes)
    {
        Debug.Log("hiyaaa");
        responseUI[numOfRes - 1].SetActive(true);
        currentResUI = responseUI[numOfRes - 1];
        addRes = currentResUI.GetComponent<AddResponseText>();
        addRes.addText(sentences[currentSentence].responseList);
    }

    public int getCurrentSentence() { return currentSentence; }
    public Sentence[] GetSentences() { return sentences; }
}
