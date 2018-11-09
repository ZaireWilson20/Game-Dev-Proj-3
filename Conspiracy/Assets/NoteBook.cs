using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour
{
    public Image background;
    public int count = 200;
  
    public Text debunked;
    public Text title;
    public Text given;
    public Text clueOneYeti;
    public Image clueTwoYeti;
    public Text clueOne;
    public Text clueTwo;
    
    public Sprite yetiPhoto;
    public Sprite transparentBackground;
    public Sprite map;

    public bool firstYeti = false;
    public bool secondYeti = false;
    public bool firstAlien = false;
    public bool secondAlien = false;
    public bool firstCult = false;
    public bool secondCult = false;
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
    void Start()
    {
        //background = GameObject.FindObjectOfType<Image>();
        background = GameObject.FindWithTag("Background").GetComponent<Image>() as Image;

        clueOneYeti = GameObject.FindWithTag("firstYeti").GetComponent<Text>() as Text;
        clueTwoYeti = GameObject.FindWithTag("secondYeti").GetComponent<Image>() as Image;

        clueOne = GameObject.FindWithTag("firstClue").GetComponent<Text>() as Text;
        clueTwo = GameObject.FindWithTag("secondClue").GetComponent<Text>() as Text;

        debunked = GameObject.FindWithTag("debunk").GetComponent<Text>() as Text;
        title = GameObject.FindWithTag("title").GetComponent<Text>() as Text;
        given = GameObject.FindWithTag("given").GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the notebook is in use or is flipping pages
        if (noteBook == false || begin == true)
        {
            MakeTransparent();
        }
        //if the key is hit, pull up the nb
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (noteBook == true)
            {
                noteBook = false;
                count = 200;
                pageOne = false;
                pageTwo = false;
                pageThree = false;
                pageFour = false;
                pageFive = false;
            }
            else
            {
                begin = true;
                open = true;
                noteBook = true;
            }
        }
        //countdown to open 
        if (begin == true)
        {
            count = count - 1;
        }
        //opened nb
        if (count == 0)
        {
            begin = false;
            //noteBook = true;
            //checks if it's the first open, or if it is flipping pages
            //reset count
            count = 20;
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
                open = false;
                FirstPage();
            }
        }
        //if the nb is open
        if (noteBook == true)
        {
            //for flipping pages back and forth
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!pageFive)
                {
                    begin = true;
                    rightFlip = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!pageOne)
                {
                    begin = true;
                    leftFlip = true;
                }
            }
        }
    }
    //right flip, checks for the correct page
    void PageFlipRight()
    {
        rightFlip = false;
	   AudioManager am = FindObjectOfType<AudioManager>();
        if (pageOne == true)
        {
            pageOne = false;
            SecondPage();
            am.Play("Flip Page 1");
        }
        else if (pageTwo == true)
        {
            pageTwo = false;
            ThirdPage();
            am.Play("Flip Page 3");
        }
        else if (pageThree == true)
        {
            pageThree = false;
            FourthPage();
            am.Play("Flip Page 2");
        }
        else if (pageFour == true)
        {
            pageFour = false;
            FifthPage();
            am.Play("Flip Page 1");
        }

    }
    //left flip, finds the right page
    void PageFlipLeft()
    {
        leftFlip = false;
	   AudioManager am = FindObjectOfType<AudioManager>();
        if (pageTwo == true)
        {
            pageTwo = false;
            //Debug.Log("Page one");
            FirstPage();
            am.Play("Flip Page 1");
        }
        else if (pageThree == true)
        {
            pageThree = false;
            SecondPage();
            am.Play("Flip Page 2");
        }
        else if (pageFour == true)
        {
            pageFour = false;
            ThirdPage();
            am.Play("Flip Page 3");
        }
        else if (pageFive == true)
        {
            pageFive = false;
            FourthPage();
            am.Play("Flip Page 2");
        }
    }
    //for each of the pages, loads in the correct sprites to the images
    void FirstPage()
    {
        //Intro to the nb
        pageOne = true;
        title.text = "Notes" + "\n" + "Be careful";
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
        //switch all the sprites to the correct clues if they were given
        title.text = "Yeti Theory";
        given.text = "Lives in the forest" + "\n" + "Carnivorous; Hunts at night" + "\n" +
            "Goes for individuals, not groups" + "\n" + "Apex predator (probably???)";
        if (firstYeti == true && secondYeti == true)
        {
            debunked.text = "Debunked";
        }
        if (firstYeti == true)
        {
            clueOneYeti.text = "TALK TO SKINNER!!! Convenience store, wears big ‘ol top hat";
        }
        if (secondYeti == true)
        {
            clueTwoYeti.sprite = yetiPhoto;
        }
    }
    void FourthPage()
    {
        //Alien theory
        pageFour = true;
        title.text = "Alien Abduction";
        given.text = "Abduct people for experiments" + "\n" + 
            "Unexplainable lights in the sky (airplanes, maybe???)";
        if (firstAlien == true && secondAlien == true)
        {
            debunked.text = "Debunked";
        }
        if (firstAlien == true)
        {
            clueOne.text = "TALK TO FINN!!! Down at the bar, NOT clean-shaven";
        }
        if (secondAlien == true)
        {
            clueTwo.text = "GOTTA POKE A HOLE IN FINN’S STORY!";
        }
    }
    void FifthPage()
    {
        //Cult theory
        pageFive = true;
        title.text = "Cult Theory";
        given.text = "Sacrifice victims to some sort of Eldritch God in exchange for immortality, " +
            "wealth, the usual" + "\n" +
            "Hidden temple underneath the Church" + "\n" + "Everyone is in on it???";
        if (firstCult == true)
        {
            clueOne.text = "No one wants to talk to me about it. Maybe everyone IS in on it . . .";
        }
        if (secondCult == true)
        {
            clueTwo.text = "If this is real . . . are the townspeople spreading the other theories as cover-ups? Who’s in on this thing?";
        }
        if (firstCult == true && secondCult == true)
        {
            debunked.text = "IT'S REAL I SHOULD RUN";
        }
    }
    //sets them all back to transparent
    void MakeTransparent()
    {
        //Set all the images to transparent when the book is not in use or is flipping pages
        background.sprite = transparentBackground;
        clueTwoYeti.sprite = transparentBackground;
        clueOne.text = "";
        clueTwo.text = "";
        clueOneYeti.text = "";
        title.text = "";
        given.text = "";
        debunked.text = "";
    }
}

