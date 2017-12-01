using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    //Animation anim;
    SpriteRenderer spr;
    InputManager im;

    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;

    // Use this for initialization
    void Start ()
    {
        //anim = GetComponent<Animation>();
        spr = GetComponent<SpriteRenderer>();
        im = GetComponent<InputManager>();
        spr.GetComponent<SpriteRenderer>().sprite = Up;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovingDirection();
    }

    void MovingDirection()
    {
        if (im.Up())
        {
            spr.GetComponent<SpriteRenderer>().sprite = Up;
        }
        if (im.Down())
        {
            spr.GetComponent<SpriteRenderer>().sprite = Down;
        }
        if (im.Left())
        {
            spr.GetComponent<SpriteRenderer>().sprite = Left;
        }
        if (im.Right())
        {
            spr.GetComponent<SpriteRenderer>().sprite = Right;
        }
    }
}
