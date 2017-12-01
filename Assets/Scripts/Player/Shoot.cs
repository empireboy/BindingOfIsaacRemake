using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private InputManager im;
    public BulletMovement bulletPrefab;
    public GameObject player;
    public float initialTimer = 5;
    public float timer;


    // Use this for initialization
    void Start ()
    {
        im = GetComponent<InputManager>();
        player = GameObject.Find("Player");
    }

    public void Shot(BulletMovement.ShootDirectionType dir)
    {
        BulletMovement bullet = Instantiate(bulletPrefab, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
        bullet.SetDirectionType(dir);
    }
    public bool CanShoot()
    {
        if (timer > 0)
        {
            timer--;
            return false;
        }
        else if (timer <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	void Update ()
    {
        if (CanShoot())
        {
            if (im.ShootUp())
            {
                Shot(BulletMovement.ShootDirectionType.Up);
                timer = initialTimer;
            }
            if (im.ShootDown())
            {
                Shot(BulletMovement.ShootDirectionType.Down);
                timer = initialTimer;
            }
            if (im.ShootLeft())
            {
                Shot(BulletMovement.ShootDirectionType.Left);
                timer = initialTimer;
            }
            if (im.ShootRight())
            {
                Shot(BulletMovement.ShootDirectionType.Right);
                timer = initialTimer;
            }
        }
    }

}
