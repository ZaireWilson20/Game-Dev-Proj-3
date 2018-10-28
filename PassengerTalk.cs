using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DialogCat { none, start, sameHouse, whatColor, notYellow, notRed, awkSilence, favYellow, prefBlue, likeCube, grandpaCube, ownCube, boringCube }

[System.Serializable]
public class DialogDef
{
    public DialogCat category = DialogCat.none;
    public string prompt;
    public string option1;
    public int score1;
    public DialogCat next1 = DialogCat.none;
    public string option2;
    public int score2;
    public DialogCat next2 = DialogCat.none;
    public string option3;
    public int score3;
    public DialogCat next3 = DialogCat.none;
    public string option4;
    public int score4;
    public DialogCat next4 = DialogCat.none;
}

public class PassengerTalk : MonoBehaviour {

    DialogDef current;
    public DialogCat _cat = DialogCat.none;
    public DialogCat cat
    {
        get
        {
            return (_cat);
        }
        set
        {
            _cat = value;
            if (_cat == DialogCat.none)
            {
                return;
            }
            current = Talk.GetDialogDefinition(_cat);
        }
    }
    GameObject prompt;
    GameObject option1;
    GameObject option2;
    GameObject option3;
    GameObject option4;
    public Text currentScore;
    public int score;
    public bool canRespond;
    bool responded;
    float lastTime = 0;

    // Use this for initialization
    void Start () {
        currentScore.text = "Score: " + score.ToString();
        current = Talk.GetDialogDefinition(_cat);
        prompt = transform.Find("Prompt").gameObject;
        option1 = transform.Find("Option1").gameObject;
        option2 = transform.Find("Option2").gameObject;
        option3 = transform.Find("Option3").gameObject;
        option4 = transform.Find("Option4").gameObject;
        prompt.GetComponent<TextMesh>().text = current.prompt;
        option1.GetComponent<TextMesh>().text = "1) " + current.option1;
        option2.GetComponent<TextMesh>().text = "2) " + current.option2;
        option3.GetComponent<TextMesh>().text = "3) " + current.option3;
        option4.GetComponent<TextMesh>().text = "4) " + current.option4;
        score = 0;
        canRespond = false;
        responded = false;
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (canRespond)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                score += current.score1;
                lastTime = Time.time;
                responded = true;
                current = Talk.GetDialogDefinition(current.next1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                score += current.score2;
                lastTime = Time.time;
                responded = true;
                current = Talk.GetDialogDefinition(current.next2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                score += current.score3;
                lastTime = Time.time;
                responded = true;
                current = Talk.GetDialogDefinition(current.next3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                score += current.score4;
                lastTime = Time.time;
                responded = true;
                current = Talk.GetDialogDefinition(current.next4);
            }
            if (responded)
            {
                canRespond = false;
                responded = false;
                prompt.GetComponent<TextMesh>().text = current.prompt;
                option1.GetComponent<TextMesh>().text = "1) " + current.option1;
                option2.GetComponent<TextMesh>().text = "2) " + current.option2;
                option3.GetComponent<TextMesh>().text = "3) " + current.option3;
                option4.GetComponent<TextMesh>().text = "4) " + current.option4;
            }
            currentScore.text = "Score: " + score.ToString();
        }
        if (Time.time - lastTime > 3)
        {
            canRespond = true;
        }
    }
}


