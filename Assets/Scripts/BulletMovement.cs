using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public enum ShootDirectionType
    {
        Up,
        Down,
        Left,
        Right
    }

    Rigidbody2D rgb2;
    public float speed = 10;

   // public int direction;
    private ShootDirectionType directionType;
    private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
        rgb2 = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rgb2.transform.position += moveDirection * speed * Time.deltaTime;
        /*
		if(direction == 1)
        {
            Debug.Log("omhoog");
            rgb2.transform.position += transform.up * speed * Time.deltaTime;
        }
        if (direction == 2)
        {
            Debug.Log("onlaag");
            rgb2.transform.position += transform.up * -speed * Time.deltaTime;
        }
        if (direction == 3)
        {
            Debug.Log("links");
            rgb2.transform.position += transform.right * speed * Time.deltaTime;
        }
        if (direction == 4)
        {
            Debug.Log("rechts");
            rgb2.transform.position += transform.right * -speed * Time.deltaTime;
        }
        */
    }

    public void SetDirectionType(ShootDirectionType type)
    {
        switch(type)
        {
            case ShootDirectionType.Up:
                moveDirection = Vector3.up;
                break;
            case ShootDirectionType.Down:
                moveDirection = Vector3.down;
                break;
            case ShootDirectionType.Left:
                moveDirection = Vector3.left;
                break;
            case ShootDirectionType.Right:
                moveDirection = Vector3.right;
                break;
        }
    }
}
