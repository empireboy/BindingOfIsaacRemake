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
    Vector2 velocity = new Vector2();

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

        /*if (im.Up())
        {
            rgb2.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (im.Down())
        {
            rgb2.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (im.Left())
        {
            rgb2.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (im.Right())
        {
            rgb2.transform.position += Vector3.right * speed * Time.deltaTime;
        }*/
    }
}
