using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("there is a hit");
        if(other.gameObject.layer == 9)
        {
            if(other.gameObject.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                DecrementHealth();
                Destroy(other.gameObject);
            }
        }
    }

    private void DecrementHealth()
    {
        health -= 1;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
