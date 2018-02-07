using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemies : MonoBehaviour {

    public GameObject[] objects;
    public GameObject player;
    public float spawnerTime = 6f;
    bool hasBeenCalled = false;
    private Vector3 spawnPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasBeenCalled)
        {
            hasBeenCalled = true;
            InvokeRepeating("Spawn", spawnerTime, spawnerTime);
        }
	}

    void Spawn()
    {
        spawnPos.x = Random.Range(-9, 9);
        spawnPos.y = Random.Range(-5, 5);
        spawnPos.z = 0;
        int colorDet = Random.Range(0, 3);
        GameObject spawned = Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPos, Quaternion.identity);
        if (colorDet == 0)
        {
            spawned.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (colorDet == 1)
        {
            spawned.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (colorDet == 2)
        {
            spawned.GetComponent<SpriteRenderer>().color = Color.red;
        }
        spawned.GetComponent<BaseWaveMovement>().SetController();
    }
}
