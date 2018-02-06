using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public int health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getHealth()
    {
        return health;
    }

    public bool isGreen()
    {
        return GetComponent<SpriteRenderer>().color == Color.green;
    }

    public bool isBlue()
    {
        return GetComponent<SpriteRenderer>().color == Color.blue;
    }

    public bool isRed()
    {
        return GetComponent<SpriteRenderer>().color == Color.red;
    }
}
