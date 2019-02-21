using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy stays on platform if it's colliding with it
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }

        //Resets scene if player is hit by Enemy
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Destry the bullet on impact
        if (collision.transform.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }

    //if the enemy is not on the platform - the object is no longer a children
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
