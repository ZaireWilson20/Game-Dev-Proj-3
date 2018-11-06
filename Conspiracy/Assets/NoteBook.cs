using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour {
    public Image background;
    public Image clueOne;
    public Sprite warning;
    public Sprite map;
    public Sprite pageThreeSprite;
    public Sprite pageFourSprite;
    public Sprite pageFiveSprite;
    public Sprite transparentBackground;
    public int count = 200;
    bool begin = false;
    bool open = false;
    bool noteBook = false;
    bool pageOne = false;
    bool pageTwo = false;
    bool pageThree = false;
    bool pageFour = false;
    bool pageFive = false;
    bool rightFlip = false;
    bool leftFlip = false;



    // Use this for initialization
    void Start () {
        background = GameObject.FindWithTag("background").GetComponent<Image>() as Image;
        clueOne = GameObject.FindWithTag("clue").GetComponent<Image>() as Image;
    }
	
	// Update is called once per frame
	void Update () {
        if (noteBook == false)
        {
            background.sprite = transparentBackground;
            clueOne.sprite = transparentBackground;
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
                open = true;
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
            if (leftFlip == true)
            {
                PageFlipLeft();
            }
            else if (rightFlip == true)
            {
                PageFlipRight();
            }
            else if (open == true)
            {
                FirstPage();
                open = false;
            }
            /*if (pageOne == false && pageTwo == false)
            {
                //pageOne = true;
                //background.sprite = pageOneSprite;
                FirstPage();
            }
            else if (pageOne == false && pageTwo == true)
            {
                //background.sprite = pageTwoSprite;
                FirstPage();
            }
            else if (pageOne == true && pageTwo == false)
            {
                //background.sprite = pageOneSprite;
                SecondPage();
            }*/
            count = 20;
        }
        if (noteBook == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && pageOne == true)
            {
                /*begin = true;
                pageOne = false;
                pageTwo = true;
                background.sprite = transparentBackground;*/
                if (pageTwo != true)
                {
                    //PageFlipRight();
                    begin = true;
                    rightFlip = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && pageTwo == true)
            {
                /*begin = true;
                pageOne = true;
                pageTwo = false;
                background.sprite = transparentBackground;*/
                if (pageOne != true)
                {
                    //PageFlipLeft();
                    begin = true;
                    leftFlip = true;
                }
            }
        }
    }

    void PageFlipRight()
    { 
        if (pageOne == true)
        {
            SecondPage();
        }
        else if (pageTwo == true)
        {
            ThirdPage();
        }
        else if (pageThree == true)
        {
            FourthPage();
        }
        else if (pageFour == true)
        {
            FifthPage();
        }

    }
    void PageFlipLeft()
    {
        if (pageTwo == true)
        {
            FirstPage();
        }
        else if (pageThree == true)
        {
            SecondPage();
        }
        else if (pageFour == true)
        {
            ThirdPage();
        }
        else if (pageFive == true)
        {
            FourthPage();
        }
    }

    void FirstPage()
    {
        //Intro to the nb
        pageOne = true;
        background.sprite = warning;
    }

    void SecondPage()
    {
        //map of the town
        pageTwo = true;
        background.sprite = map;
    }
    void ThirdPage()
    {
        //Yeti theory
        pageThree = true;
        background.sprite = pageThreeSprite;
    }
    void FourthPage()
    {
        //Alien theory
        pageFour = true;
        background.sprite = pageFourSprite;
    }
    void FifthPage()
    {
        //Cult theory
        pageFive = true;
        background.sprite = pageFiveSprite;
    }
}
