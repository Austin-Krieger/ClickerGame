using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    #region Fields
    Rigidbody2D rbody;
    private int constantSpeed;
    #endregion

    #region Methods
    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        rbody.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);
        constantSpeed = 10;
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
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
    #endregion
}
