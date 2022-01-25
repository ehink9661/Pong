using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public Scoreboard scoreboard;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject wallBC;
    private GameObject overlay;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    private Scoreboard score1;

    private Scoreboard score2;
    // Start is called before the first frame update
    void Start()
    {
        overlay = GameObject.Find("Canvas");
        // convert screen's pixel coordinates into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // create ball
        ball = Instantiate(ball);
        
        // create paddle
        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);
        paddle1.Init(true); // right paddle
        paddle2.Init(false); // left paddle
        
        // create score
        score1 = Instantiate(scoreboard);
        score2 = Instantiate(scoreboard);
        score1.Init(true);
        score2.Init(false);
        score1.transform.SetParent(overlay.transform);
        score2.transform.SetParent(overlay.transform);
    }

    public void scored1()
    {
        score1.score++;
        score1.GetComponent<TextMeshProUGUI>().text = score1.score.ToString();
    }
    
    public void scored2()
    {
        score2.score++;
        score2.GetComponent<TextMeshProUGUI>().text = score2.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h")) // help menu
        {
            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown("c")) // classic mode
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            ball.rstPosition();
            score1.score = 0;
            score1.GetComponent<TextMeshProUGUI>().text = score1.score.ToString();
            score2.score = 0;
            score2.GetComponent<TextMeshProUGUI>().text = score2.score.ToString();
            wallBC.SetActive(false);
        }
        
        if (Input.GetKeyDown("b")) // classic mode
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            ball.rstPosition();
            score1.score = 0;
            score1.GetComponent<TextMeshProUGUI>().text = score1.score.ToString();
            score2.score = 0;
            score2.GetComponent<TextMeshProUGUI>().text = score2.score.ToString();
            wallBC.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }
}
