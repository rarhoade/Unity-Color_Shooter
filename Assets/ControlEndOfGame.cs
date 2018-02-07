using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.SceneManagement;

public class ControlEndOfGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(InputManager.ActiveDevice.GetControl(InputControlType.Action1).IsPressed || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
        else if(InputManager.ActiveDevice.GetControl(InputControlType.Select) || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
