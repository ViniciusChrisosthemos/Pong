using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne = true;
    [SerializeField][Range(5, 15)] private float speed = 5f;
    [SerializeField] private float maxAngle = 45f;

    private Transform myTransform;

    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    private float halfWidth;
    private float movement;

    private void Awake()
    {
        myTransform = gameObject.transform;

        halfWidth = gameObject.transform.lossyScale.y / 2f;
    }

    private void Update()
    {
        if (isPlayerOne)
            movement = Input.GetAxis("Player1Movement");
        else
            movement = Input.GetAxis("Player2Movement");

        myTransform.position = new Vector3(myTransform.position.x, Mathf.Clamp(myTransform.position.y + movement * speed * Time.deltaTime, minHeight, maxHeight));
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Ball"))
        {
            maxAngle = 45f;
            float intensity = Mathf.Abs(Mathf.Abs(_collision.transform.position.y) - Mathf.Abs(myTransform.position.y)) / halfWidth;

            GameObject ball = _collision.gameObject;
            if (myTransform.position.y < _collision.transform.position.y)
                ball.transform.Rotate(new Vector3(0, 0, 180 - maxAngle * intensity));
            else
                ball.transform.Rotate(new Vector3(0, 0, 180 + maxAngle * intensity));

            GameMaster.Instance.IncreaseBallSpeed();
        }
    }

    internal void SetSpeed(float _value)
    {
        speed = _value;
    }
}
