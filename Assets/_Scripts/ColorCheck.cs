using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorCheck : MonoBehaviour {
    public int colorStack = 0;
    public int stackLimit = 10;
    public int scoreLimit = 10;
    public Text scoreboard;
    public int score = 0;
    public Slider bulletTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 8)
        {
            if (collision.collider.gameObject.GetComponent<SpriteRenderer>().color != this.GetComponent<SpriteRenderer>().color)
            {
                if (!GetComponent<PlayerState>().getIsVuln())
                {
                    score = 0;
                    GetComponent<ShootProjectile>().resetShotSpeed();
                    bulletTimer.value = 0;
                    GetComponent<PlayerState>().takeDamage();
                }
            }
            else
            {
                colorStack += 1;
                GetComponent<PlayerState>().IncrementScore();
                if(colorStack >= stackLimit)
                {
                    colorStack = 0;
                    score += 1;
                    GetComponent<ShootProjectile>().makeShotsFaster();
                }
                bulletTimer.value = colorStack;
            }
            updateScore();
        }
    }

    private void updateScore()
    {
        scoreboard.text = "Score: " + score.ToString();
        if(score >= scoreLimit)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
