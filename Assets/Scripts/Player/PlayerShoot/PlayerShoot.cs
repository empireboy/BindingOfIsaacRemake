using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private AudioSource _shootSound;
    private PlayerMovement _movement;
    private InputManager _im;
    public BulletMovement bulletPrefab;
    public float initialTimer = 1;
    public float timer;
    public BulletMovement.ShootDirectionType shootDirection;
    public BulletMovement.WalkDirection walkDirection;
    public float maxVelocity = 0.05f;

    public bool shooting = false;
	public bool leftEye = false;
    private Vector3 _bulletSpawnPos;


    // Use this for initialization
    void Start ()
    {
        _im = GetComponent<InputManager>();
        _movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _shootSound = GetComponent<AudioSource>();
    }
    
    public void Shot(BulletMovement.ShootDirectionType shootDir, BulletMovement.WalkDirection walkDir)
    {
        AudioSource.PlayClipAtPoint(_shootSound.clip, new Vector3(5, 1, 2));
            shooting = true;
			BulletMovement bullet = Instantiate(bulletPrefab, _bulletSpawnPos, Quaternion.identity);
            bullet.SetDirectionType(shootDir);
            bullet.SetWalkDirectionType(walkDir);
    }
    
    public bool CanShoot()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
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
            if (_movement.velocity.y > maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Up;
            }
            else if (_movement.velocity.y < -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Down;
            }

            if(_movement.velocity.x > maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Right;
            }
            else if(_movement.velocity.x < -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.Left;
            }

            if(_movement.velocity.y < maxVelocity &&
               _movement.velocity.y > -maxVelocity &&
               _movement.velocity.x < maxVelocity &&
               _movement.velocity.x > -maxVelocity)
            {
                walkDirection = BulletMovement.WalkDirection.None;
            }

            //Debug.Log(movement.velocity.x);
            
            if (_im.ShootUp())
            {
                if (leftEye)
                {
                    _bulletSpawnPos = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y+0.1f, gameObject.transform.position.z);
                    leftEye = false;
                }
                else if (!leftEye)
                {
                    _bulletSpawnPos = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y+ 0.1f, gameObject.transform.position.z);
                    leftEye = true;
                }
                Shot(BulletMovement.ShootDirectionType.Up, walkDirection);
                timer = initialTimer;
            }
            else if (_im.ShootDown())
            {
                if (leftEye)
                {
                    _bulletSpawnPos = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y-0.3f, gameObject.transform.position.z);
                    leftEye = false;
                }
                else if (!leftEye)
                {
                    _bulletSpawnPos = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y-0.3f, gameObject.transform.position.z);
                    leftEye = true;
                }
                Shot(BulletMovement.ShootDirectionType.Down, walkDirection);
                timer = initialTimer;
                
            
            }

            else if (_im.ShootLeft())
            {
                _bulletSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Shot(BulletMovement.ShootDirectionType.Left, walkDirection);
                timer = initialTimer;
            }
            else if (_im.ShootRight())
            {
                _bulletSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Shot(BulletMovement.ShootDirectionType.Right, walkDirection);
                timer = initialTimer;
            }

            
        }

    }

}
