using UnityEngine;
using System.Collections;
using System;

public class GameMaster: MonoBehaviour
{
    public static GameMaster Instance { get; private set; }

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private BallController ball;
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;

    private int player1Score;
    private int player2Score;

    private void Awake()
    {
        Instance = this;

        player1Score = 0;
        player2Score = 0;
    }

    private void Start()
    {
        Time.timeScale = 0;

        ball.SetDefaultSpeed(5);
        ball.SetSpeedRatio(1);
        player1.SetSpeed(5);
        player2.SetSpeed(5);
    }

    private void Update()
    {   
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                UIManager.Instance.SetMenuScreen(false);
            }
            else
            {
                Time.timeScale = 0;
                UIManager.Instance.SetMenuScreen(true);
            }
        }
    }

    public void FinishRound(bool playerOneWinner)
    {
        ball.transform.position = initialPosition;

        if (playerOneWinner)
        {
            player1Score++;
            ball.transform.rotation = Quaternion.identity;
        }
        else
        {
            player2Score++;
            ball.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

        }

        UIManager.Instance.SetScore(player1Score, player2Score);
    }

    public void IncreaseBallSpeed()
    {
        ball.IncreaseBallSpeed();
    }

    public void SetSpeedRatio(float _value)
    {
        ball.SetSpeedRatio(_value);
    }

    public void SetDefaultSpeed(float _value)
    {
        ball.SetDefaultSpeed(_value);
    }

    internal void SetPlayerSpeed(float _value)
    {
        player1.SetSpeed(_value);
        player2.SetSpeed(_value);
    }
}
