using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour {
    public Image background;
    public Sprite pageOneSprite;
    public Sprite pageTwoSprite;
    public Sprite transparentBackground;
    public int count = 200;
    public bool begin = false;
    public bool noteBook = false;
    public bool pageOne = false;
    public bool pageTwo = false;



    // Use this for initialization
    void Start () {
        background = GameObject.FindObjectOfType<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (noteBook == false)
        {
            background.sprite = transparentBackground;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (noteBook == true)
            {
                noteBook = false;
            }
            else
            {
                begin = true;
            }
        }
        if (begin == true)
        {
            count = count - 1;
        }
        if (count == 0)
        {
            begin = false;
            noteBook = true;
            if (pageOne == false && pageTwo == false)
            {
                pageOne = true;
                background.sprite = pageOneSprite;
            }
            else if (pageOne == false && pageTwo == true)
            {
                background.sprite = pageTwoSprite;
            }
            else if (pageOne == true && pageTwo == false)
            {
                background.sprite = pageOneSprite;

            }
            count = 20;
        }
        if (noteBook == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && pageOne == true)
            {
                begin = true;
                pageOne = false;
                pageTwo = true;
                background.sprite = transparentBackground;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && pageTwo == true)
            {
                begin = true;
                pageOne = true;
                pageTwo = false;
                background.sprite = transparentBackground;
            }
        }
    }
}
