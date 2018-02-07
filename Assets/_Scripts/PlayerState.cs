using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;

public class PlayerState : MonoBehaviour {

    public int health = 10;
    public int stackingScore = 0;
    public bool isInvuln = false;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (InputManager.ActiveDevice.GetControl(InputControlType.Select) || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public Vector3 getCurrentPosition()
    {
        return transform.position;
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

    public void takeDamage()
    {
        health -= 1;
        healthSlider.value = health;
        if(health > 0)
        {
            StartCoroutine(Invulnerability());
        }
        else
        {
            Death();
        }
    }

    public bool getIsVuln()
    {
        return isInvuln;
    }

    IEnumerator Invulnerability()
    {
        isInvuln = true;
        StartCoroutine(flashSprite());
        yield return new WaitForSeconds(2f);
        isInvuln = false;
    }

    IEnumerator flashSprite()
    {
        for(int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void IncrementScore()
    {
        stackingScore += 1;
    }

    private void Death()
    {
        SceneManager.LoadScene("Main");
    }
}
