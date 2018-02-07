using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour {

    public GameObject greenWave;
    public GameObject blueWave;
    public GameObject redWave;
    public Vector3 waveOffset;
    public float waveSpeed = 5.0f;
    public bool hasShotWave = false;
    public float timeSpacing = 0.5f;
    public GameObject player;
    public GameObject controller;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!hasShotWave)
        {
            StartCoroutine(SendWave());
        }
	}

    IEnumerator SendWave()
    {
        hasShotWave = true;
        yield return new WaitForSeconds(timeSpacing);
        
        GameObject sentWave = null;
        if(GetComponent<SpriteRenderer>().color == Color.green)
        {
            sentWave = GameObject.Instantiate(greenWave);
        }
        else if(GetComponent<SpriteRenderer>().color == Color.red)
        {
            sentWave = GameObject.Instantiate(redWave);
        }
        else if (GetComponent<SpriteRenderer>().color == Color.blue)
        {
            sentWave = GameObject.Instantiate(blueWave);
        }
        sentWave.transform.position = this.transform.position;
        //Debug.Log(decider);
        sentWave.transform.up = controller.GetComponent<BroadCastPosition>().broadcastPlayer() - transform.position;
        //sentWave.transform.LookAt(player.transform.position, player.transform.position);
        sentWave.GetComponent<Rigidbody>().velocity = sentWave.transform.up * waveSpeed;
        hasShotWave = false;
    }

    public void SetController()
    {
        controller = GameObject.Find("EnemyController");
    }

}
