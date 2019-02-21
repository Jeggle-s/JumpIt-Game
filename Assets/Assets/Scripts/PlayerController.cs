using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private bool onGround;
    [SerializeField]
    private LayerMask theGround;
    public GameObject player;
    public Animation jump;

    private Rigidbody2D rigidChar;
    private BoxCollider2D colliding;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float fireRate = 0.5f;
    private float nextFire = 0f;


    // Use this for initialization
    void Start()
    {
        //Get RigidBody from Player
        rigidChar = GetComponent<Rigidbody2D>();

        //Enables the collision of different objects
        colliding = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {   //Call Movementmethod
        Movement();

        onGround = Physics2D.IsTouchingLayers(colliding, theGround);

        /* Spawn the player on the opposite side if he lefts the cameraview
         */
        if (transform.position.x <= -3.17f) //Point on the left side
        {
            transform.position = new Vector3(3.17f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 3.17f) //point on the right side
        {
            transform.position = new Vector3(-3.17f, transform.position.y, transform.position.z);
        }

        //player is able to shoot
        if (Input.GetAxis("Fire1") > 0)
        {
            fireBullet();
        }

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D)) //Move right
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) //Move left
        {
            transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);
        }

        float velY = GetComponent<Rigidbody2D>().velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && onGround && velY <= 0) //Jump
        {
            rigidChar.velocity = new Vector2(rigidChar.velocity.x, jumpPower);
        }
    }

    //Player is able to stay on a moving platform - player becomes children of platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    //if the player is not on the platform - the object is no longer a children
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void fireBullet()
    {
        //enables player to shoot
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

}
