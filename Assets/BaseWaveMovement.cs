using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWaveMovement : MonoBehaviour {

    public GameObject player;
    public GameObject controller;
    public float moverSpeed;
    private bool waveShot = false;
    private bool hasMoved = false;
    public float moveTime = 90f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasMoved)
        {
            StartCoroutine(WaverMovement());
        }
        transform.up = transform.position - controller.GetComponent<BroadCastPosition>().broadcastPlayer();
    }

    IEnumerator WaverMovement()
    {
        float time = 0;
        hasMoved = true;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            transform.position = transform.position - (transform.position - controller.GetComponent<BroadCastPosition>().broadcastPlayer()) * Time.deltaTime * moverSpeed;
            
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        hasMoved = false;
    }

    public void SetController()
    {
        controller = GameObject.Find("EnemyController");
        GetComponent<SpawnWaves>().SetController();
    }
}
