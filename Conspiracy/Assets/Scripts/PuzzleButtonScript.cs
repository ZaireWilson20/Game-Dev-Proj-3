using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButtonScript : MonoBehaviour {

    public bool selected = false;
    Color selectedColor = new Color(1f, 0f, 0f);
    Color notSelectedColor = new Color(1f, 1f, 1f);
    PuzzleManagerScript managerScript;

    Image image;

    private void Start()
    {
        managerScript = GameObject.Find("PuzzleManager").GetComponent<PuzzleManagerScript>();

        image = gameObject.GetComponent<Image>();
    }

    public void Select()
    {
        image.color = selectedColor;
        selected = true;
        managerScript.Selected();
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
        selected = false;
    }
}