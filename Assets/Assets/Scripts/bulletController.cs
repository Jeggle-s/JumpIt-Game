using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    Rigidbody2D myRB;
    public float speed = 1;
    public float aliveTime;

    // Use this for initialization
    void Awake ()
    {
        myRB = GetComponent<Rigidbody2D>();

        //shooting the bullet in a 90° angle from the player upwards
        myRB.AddForce(new Vector2(0, 1) * speed, ForceMode2D.Impulse);

        //Destroy bullet after certain amount of time
        Destroy(gameObject, aliveTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy bullet if it hits an enemy
        if (collision.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
