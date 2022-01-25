using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private GameManager gm;
    private float radius;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = Vector2.one.normalized; // direction 1,1 normalized
        radius = transform.localScale.x / 2;
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));

        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y; // invert direction
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y; // invert direction
        }
        
        // win tracker
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0) // checks edge of screen
        {
            Debug.Log("Right Player Wins!");
            rstPosition();
            gm.scored1();
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player Wins!");
            rstPosition();
            gm.scored2();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            // hits right paddle going right
            if (isRight && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            // hits left paddle going left
            if (!isRight && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }

        if (other.tag == "Wall") // dr bc mode wall
        {
            direction.x = -direction.x;
        }
    }

    public void rstPosition()
    {
        Debug.Log("rst asserted");
        speed = 6f;
        transform.position = Vector2.zero;
        direction.x = -direction.x;
        direction.y = -direction.y;
    }
}
