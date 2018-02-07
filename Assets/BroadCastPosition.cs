using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadCastPosition : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(player.transform.position);
	}

    public Vector3 broadcastPlayer()
    {
        return player.transform.position;
    }


}
