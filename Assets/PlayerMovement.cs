using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody rb;
    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(x, y, 0);
        MoveCharacter(input);
	}

    void MoveCharacter(Vector3 direction)
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        max.x = max.x - 0.25f;
        min.x = min.x + 0.25f;

        max.y = max.y - 0.25f;
        min.y = min.y + 0.25f;

        Vector3 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
