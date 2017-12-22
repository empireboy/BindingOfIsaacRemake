using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public GameObject bullet;
    private Vector3 _bulletPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            _bulletPos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            Destroy(other.gameObject);
            Instantiate(bullet, _bulletPos, Quaternion.identity);
        }
    }
}
