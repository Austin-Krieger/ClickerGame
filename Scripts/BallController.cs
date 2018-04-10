using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody2D rbody;
    private int constantSpeed;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        constantSpeed = 10;
    }

    private void LateUpdate()
    {
        rbody.velocity = constantSpeed * (rbody.velocity.normalized);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(new Vector2(5,5), ForceMode2D.Impulse);
        }
    }
}
