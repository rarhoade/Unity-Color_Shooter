using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Being Called");
            colorTake.color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Being Called");
            colorTake.color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Being Called");
            colorTake.color = Color.red;
        }
    }
}
