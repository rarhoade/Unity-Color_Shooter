using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour {

    public GameObject greenBullet;
    public GameObject blueBullet;
    public GameObject redBullet;
    private bool shooting = false;
    public float baseShot = .10f;
    public float shotTiming = .10f;

    public float firingSpeed = 10.0f;
    


    // Update is called once per frame
    void Update () {
        InputDevice device = InputManager.ActiveDevice;
        InputControl control = device.GetControl(InputControlType.RightTrigger);
        if ((Input.GetKey(KeyCode.Space) || control.IsPressed) && !shooting && GetComponent<SpriteRenderer>().color != Color.white)
        {
            StartCoroutine(shootBullet());
        }
	}

    IEnumerator shootBullet()
    {
        shooting = true;
        GameObject shot = null;
        float dirX = InputManager.ActiveDevice.GetControl(InputControlType.RightStickX);
        float dirY = InputManager.ActiveDevice.GetControl(InputControlType.RightStickY);
        Vector3 shotDir = new Vector3(dirX, dirY, 0);
        if(dirX != 0 && dirY != 0)
        {
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
            shot.transform.position = this.transform.position;
            shot.GetComponent<Rigidbody>().velocity = shotDir * firingSpeed;
        }
        
        yield return new WaitForSeconds(shotTiming);
        shooting = false;
    }

    public void makeShotsFaster()
    {
        if(shotTiming >= 0.02f)
        {
            shotTiming -= 0.01f;
        }
    }

    public void resetShotSpeed()
    {
        shotTiming = baseShot;
    }
}
