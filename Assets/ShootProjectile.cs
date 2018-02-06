using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {

    public GameObject greenBullet;
    public GameObject blueBullet;
    public GameObject redBullet;
    private bool shooting = false;

    public float firingSpeed = 10.0f;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && !shooting && GetComponent<SpriteRenderer>().color != Color.white)
        {
            StartCoroutine(shootBullet());
        }
	}

    IEnumerator shootBullet()
    {
        shooting = true;
        GameObject shot = null;
        Debug.Log("in the coroutine");
        if (GetComponent<SpriteRenderer>().color == Color.green)
        {
            shot = GameObject.Instantiate(greenBullet);
        }
        else if (GetComponent<SpriteRenderer>().color == Color.red)
        {
            shot = GameObject.Instantiate(redBullet);
        }
        else if (GetComponent<SpriteRenderer>().color == Color.blue)
        {
            shot = GameObject.Instantiate(blueBullet);
        }
        shot.transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
        shot.GetComponent<Rigidbody>().velocity = Vector3.up * firingSpeed;
        yield return new WaitForSeconds(0.05f);
        shooting = false;
    }
}
