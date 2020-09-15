using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField][Range(5, 25)] private float defaultSpeed = 5;
    [SerializeField][Range(1, 2)]private float speedIncreaseRatio = 1f;
    private float speed;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = gameObject.GetComponent<Transform>();

        speed = defaultSpeed;
    }

    private void Update()
    {
        myTransform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("HorizontalBar"))
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.eulerAngles * -1);
            SoundManager.Instance.PlayImpact();
        }
        else if (_collision.CompareTag("VerticalBar"))
        {
            speed = defaultSpeed;
            GameMaster.Instance.FinishRound(_collision.transform.position.x > 0);
            SoundManager.Instance.PlayPoint();
        }
    }

    public void IncreaseBallSpeed()
    {
        speed *= speedIncreaseRatio;
    }

    internal void SetSpeedRatio(float _value)
    {
        speedIncreaseRatio = _value;
    }

    internal void SetDefaultSpeed(float _value)
    {
        defaultSpeed = _value;
        speed = defaultSpeed;
    }
}
