using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    private float height;
    public int score;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        height = transform.localScale.y;;
    }
    
    public void Init(bool isRightScore)
    {
        isRight = isRightScore;
        Vector2 pos = Vector2.zero;
        if (isRightScore) // place on right of screen
        {
            pos = new Vector2(2, 4);
        }
        else // place on left of screen
        {
            pos = new Vector2(-2, 4);
        }
        // update score position
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
