using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Text player1Score;
    [SerializeField] private Text player2Score;

    [SerializeField] private Text defaultSpeedLabel;
    [SerializeField] private Slider defaultSpeedSlider;

    [SerializeField] private Text speedRatioLabel;
    [SerializeField] private Slider speedRatioSlider;

    [SerializeField] private Text playerSpeedLabel;
    [SerializeField] private Slider playerSpeedSlider;

    [SerializeField] private GameObject menuScreen;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpeedRatioChange();
        DefaultSpeedChange();
    }

    public void SetScore(int _player1Score, int _player2Score)
    {
        player1Score.text = _player1Score.ToString();
        player2Score.text = _player2Score.ToString();
    }

    public void SetMenuScreen(bool _value)
    {
        menuScreen.SetActive(_value);
    }

    public void SpeedRatioChange()
    {
        speedRatioLabel.text = speedRatioSlider.value.ToString("F");
        GameMaster.Instance.SetSpeedRatio(speedRatioSlider.value);
    }

    public void DefaultSpeedChange()
    {
        defaultSpeedLabel.text = defaultSpeedSlider.value.ToString();
        GameMaster.Instance.SetDefaultSpeed(defaultSpeedSlider.value);
    }

    public void PlayerSpeedChange()
    {
        playerSpeedLabel.text = playerSpeedSlider.value.ToString();
        GameMaster.Instance.SetPlayerSpeed(playerSpeedSlider.value);
    }
}
