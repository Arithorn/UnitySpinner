using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {
    float rotSpeed = 0;
    bool spinning = false;
    string selectedColor;
    int colorCount;
    int colorEvery;
    //string[] colors = { "Pink", "Purple", "Blue", "Green", "Yellow", "Orange", "Pink", "Purple", "Blue", "Green", "Yellow", "Orange" };
    string[] colors = { "Orange", "Yellow", "Green", "Blue", "Purple", "Pink", "Orange", "Yellow", "Green", "Blue", "Purple", "Pink" };
    // Start is called before the first frame update
    void Start () {
        colorCount = colors.Length;
        colorEvery = 360 / colorCount;
        Debug.Log (colorEvery);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            this.rotSpeed = 50;
            spinning = true;

        }
        transform.Rotate (0, 0, rotSpeed);
        this.rotSpeed *= 0.97f;
        float angle = transform.eulerAngles.z;
        if ((angle % colorEvery <= 0.2 && rotSpeed <= 0.05) && spinning) {
            rotSpeed = 0.08f;
        }

        if (this.rotSpeed <= 0.05) {
            this.rotSpeed = 0;
        }
        if (rotSpeed == 0 && spinning == true) {
            spinning = false;

            int index = (int) Math.Floor ((angle / colorEvery));
            selectedColor = colors[index];

            Debug.Log (selectedColor);

        }

    }
}