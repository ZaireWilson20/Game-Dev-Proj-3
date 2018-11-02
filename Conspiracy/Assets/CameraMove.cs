using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adaptation of https://answers.unity.com/questions/29741/mouse-look-script.html
public class CameraMove : MonoBehaviour {

    public float xSense;
    public float ySense;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    float xRot;
    float yRot;
    Quaternion rot;

    // Use this for initialization
    void Start () {
        rot = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        xRot += Input.GetAxis("Mouse X") * xSense;
        yRot += Input.GetAxis("Mouse Y") * ySense;
        xRot = Mathf.Clamp(xRot, xMin, xMax);
        yRot = Mathf.Clamp(yRot, yMin, yMax);
        Quaternion xQuat = Quaternion.AngleAxis(xRot, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(yRot, -Vector3.right);
        transform.localRotation = rot * xQuat * yQuat;
    }
}
