using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ColorChnage : MonoBehaviour {


    public SpriteRenderer colorTake;
	// Use this for initialization
    void Awake()
    {
        colorTake = GetComponent<SpriteRenderer>();
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z) || InputManager.ActiveDevice.GetControl(InputControlType.Action2))
        {
            colorTake.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.X) || InputManager.ActiveDevice.GetControl(InputControlType.Action3))
        {
            colorTake.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.C) || InputManager.ActiveDevice.GetControl(InputControlType.Action4))
        {
            colorTake.color = Color.red;
        }
    }
}
