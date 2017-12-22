using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{

    //Sprite ;
    SpriteRenderer spr;

    public Sprite[] _sprites;
    public float timer = 0.01f;
    public float initialTimer = 0.5f;

    private Sprite _nextSprite;
    private bool _changingSprite;

    InputManager im;
    PlayerShoot shoot;

    // Use this for initialization
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        im = GetComponent<InputManager>();
        shoot = GameObject.Find("PlayerHead").GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingDirection();
  
        if (_changingSprite)
        {
            ChangeSprite(_nextSprite);
        }

    }

    void ChangeSprite(Sprite sprite, float secondsToHold = 0)
    {


        if (timer <= 0)
        {
            spr.GetComponent<SpriteRenderer>().sprite = sprite;
            _changingSprite = false;
        }
        else if (!_changingSprite)
        {
            _changingSprite = _nextSprite;
            timer = secondsToHold;
            _changingSprite = true;
        }

    }

    void MovingDirection()
    {
        timer -= Time.deltaTime;

        if (im.ShootUp())
        {
            ChangeSprite(_sprites[0]);
        }
        else if (im.ShootDown() && shoot.shooting)
        {
            ChangeSprite(_sprites[4]);
            if (timer <= 0)
            shoot.shooting = false;
        }
        else if (im.ShootDown())
        {
            ChangeSprite(_sprites[1]);
        }
        else if (im.ShootLeft())
        {
            ChangeSprite(_sprites[2]);
        }
        else if (im.ShootRight())
        {
            ChangeSprite(_sprites[3]);
        }
        else if (im.Up())
        {
            ChangeSprite(_sprites[0]);
        }
        else if (im.Down())
        {
            ChangeSprite(_sprites[1]);
        }
        else if (im.Left())
        {
            ChangeSprite(_sprites[2]);
        }
        else if (im.Right())
        {
            ChangeSprite(_sprites[3]);
        }

        return;


    }
}