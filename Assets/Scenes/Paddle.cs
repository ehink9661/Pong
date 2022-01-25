using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private float height;
    private string input;
    public bool isRight;
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;
    }
    
    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if (isRightPaddle) // place on right of screen
        {
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // move a bit to the left
            input = "PaddleRight";
        }
        else // place on left of screen
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; // move a bit to the right
            input = "PaddleLeft";
        }
        // update paddle position
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        // moving the paddle
        // GetAxis is a number between -1 and 1 (-1 down, 1 up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        
        // restrict movement
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
