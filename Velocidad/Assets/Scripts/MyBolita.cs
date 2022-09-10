using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolita : MonoBehaviour
{
    private MyVector position;

    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;

    [Header("world")]
    [SerializeField] private Camera camera;
    private int currentAccelerationCounter = 0;
    private readonly MyVector[] directions = new MyVector[4]
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0)
    };

    // Start is called before the first frame update
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);

    }

    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    private void Update()
    {
        velocity.Draw(position, Color.red);
        position.Draw(Color.blue);
        acceleration.Draw(position, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(currentAccelerationCounter++) % directions.Length];
            velocity *= 0;
        }

    }
    void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;


        if (position.x > camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.x < -camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = -camera.orthographicSize;
            velocity *= dampingFactor;
        }

        if (position.y > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = camera.orthographicSize;
            velocity *= dampingFactor;
        }
        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = -camera.orthographicSize;
            velocity *= dampingFactor;
        }


        transform.position = new Vector3(position.x, position.y, 0);
    }
}
