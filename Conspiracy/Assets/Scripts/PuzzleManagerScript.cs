using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManagerScript : MonoBehaviour {

    int numSelected = 0;

    PuzzleButtonScript button0;
    PuzzleButtonScript button1;
    PuzzleButtonScript button2;
    PuzzleButtonScript button3;
    PuzzleButtonScript button4;
    PuzzleButtonScript button5;
    PuzzleButtonScript button6;
    PuzzleButtonScript button7;

    void Start()
    {
        button0 = GameObject.Find("PuzzleButton0").GetComponent<PuzzleButtonScript>();
        button1 = GameObject.Find("PuzzleButton1").GetComponent<PuzzleButtonScript>();
        button2 = GameObject.Find("PuzzleButton2").GetComponent<PuzzleButtonScript>();
        button3 = GameObject.Find("PuzzleButton3").GetComponent<PuzzleButtonScript>();
        button4 = GameObject.Find("PuzzleButton4").GetComponent<PuzzleButtonScript>();
        button5 = GameObject.Find("PuzzleButton5").GetComponent<PuzzleButtonScript>();
        button6 = GameObject.Find("PuzzleButton6").GetComponent<PuzzleButtonScript>();
        button7 = GameObject.Find("PuzzleButton7").GetComponent<PuzzleButtonScript>();

        buttons[0] = button0;
        buttons[1] = button1;
        buttons[2] = button2;
        buttons[3] = button3;
        buttons[4] = button4;
        buttons[5] = button5;
        buttons[6] = button6;
        buttons[7] = button7;
    }

    PuzzleButtonScript[] buttons = new PuzzleButtonScript[8];

    public void Selected()
    {
        numSelected++;
        if (numSelected == 2)
        {
            numSelected = 0;
            if (button0.selected && button6.selected)
            {
                //send a message to notebook
                //set a flag to pull up some dialogue
                SceneManager.LoadScene("Map");
            }
            else
            {
                foreach (PuzzleButtonScript script in buttons)
                {
                    script.Deselect();
                }
            }
        }
    }
}