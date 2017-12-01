using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody2D rgb2;
    InputManager im;
    public float speed = 3;
    public float accel = 20;
    public float friction = 200;
    public float maxSpeed = 5;
    Vector3 velocity = new Vector2();

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        im = GetComponent<InputManager>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if(im.Up())
        {
            velocity.y += speed * Time.deltaTime;
            if (velocity.y > maxSpeed)
                velocity.y = maxSpeed;
        }
        else if(im.Down())
        {
            velocity.y -= speed * Time.deltaTime;
            if (velocity.y < -maxSpeed)
                velocity.y = -maxSpeed;
        }
        else
        {
            if(velocity.y > 0)
            {
                velocity.y -= friction * Time.deltaTime;
                if (velocity.y < 0) velocity.y = 0;
            }
            else if(velocity.y < 0)
            {
                velocity.y += friction * Time.deltaTime;
                if (velocity.y > 0) velocity.y = 0;
            }
        }

        if (im.Right())
        {
            velocity.x += speed * Time.deltaTime;
            if (velocity.x > maxSpeed)
                velocity.x = maxSpeed;
        }
        else if (im.Left())
        {
            velocity.x -= speed * Time.deltaTime;
            if (velocity.x < -maxSpeed)
                velocity.x = -maxSpeed;
        }
        else
        {
            if (velocity.x > 0)
            {
                velocity.x -= friction * Time.deltaTime;
                if (velocity.x < 0) velocity.x = 0;
            }
            else if (velocity.x < 0)
            {
                velocity.x += friction * Time.deltaTime;
                if (velocity.x > 0) velocity.x = 0;
            }
        }

        rgb2.velocity = Vector2.zero;
        rgb2.MovePosition(transform.position + velocity);
    }
}
