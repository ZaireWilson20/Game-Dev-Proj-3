using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButtonScript : MonoBehaviour {

    public bool selected = false;
    Color selectedColor = new Color(0.2265625f, 0.015625f, 0.015625f);
    Color32 notSelectedColor = new Color32(130, 105, 69, 255);
    PuzzleManagerScript managerScript;

    Image image;

    private void Start()
    {
        managerScript = GameObject.Find("PuzzleManager").GetComponent<PuzzleManagerScript>();

        image = gameObject.GetComponent<Image>();

        image.color = notSelectedColor;
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