using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Camera control
    public Transform player;
    float playerCoordinates;
    private Vector3 offset; //difference between old an new position

    //Platforms
    public Transform grass;
    public Transform wood;
    public Transform ice;
    public Transform woodEnemy;
    public Transform boostPlat;

    //PlatformSpawn
    private float platCheck;
    private int platformIndex;
    private float platformSpace;

    //Scoreelements
    public Text scoreText;
    public int score;


	// Use this for initialization
	void Start ()
    {
        //Autoset the player gameobject
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Call method with spawnlocation
        PlatformSpawn(6.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Relevant coordinates for camera(y)
        playerCoordinates = player.position.y;

        if (playerCoordinates > platCheck)
        {
            PlatformCheck();
        }
        
        //Camera follows the player 
        float currentCameraHeight = transform.position.y;
        //Making the camera smooth / Camera only goes up
        float newHeightOfCam = Mathf.Lerp(currentCameraHeight, playerCoordinates, Time.deltaTime * 10f);

        //End game if player is out of cameraview
        if (playerCoordinates > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeightOfCam, transform.position.z);
        }
        else
        {
            if (playerCoordinates <= (currentCameraHeight - 4.69f))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        //Score is equal to players height
        if (playerCoordinates > score)
        {
            score = (int)playerCoordinates;
            scoreText.text = string.Format("Score: {0}", score);
        }
    }

    void PlatformCheck()
    {
        //checks if platforms are in range, else hey would spawn as soon as player jumps
        platCheck = player.position.y + 20;

        PlatformSpawn(platCheck + 20);
    }

    void PlatformSpawn(float spawnPoint)
    {
        float y = platformSpace;

        while (y <= spawnPoint)
        {
            //Width of the cameraview in which platforms are spawning
            float x = Random.Range(-1.97f, 1.97f);

            //Pick random platform between 1 and 6
            platformIndex = Random.Range(1, 6);

            //Vector which sets given x and y coordinates
            Vector2 posXY = new Vector2(x, y);

            //Spawn the platform in a fixed range
            if (platformIndex == 1)
            {
                Instantiate(wood, posXY, Quaternion.identity);
            }
            if (platformIndex == 2)
            {
                Instantiate(grass, posXY, Quaternion.identity);
            }
            if (platformIndex == 3)
            {
                Instantiate(ice, posXY, Quaternion.identity);
            }
            if (platformIndex == 5)
            {
                Instantiate(woodEnemy, posXY, Quaternion.identity);
            }
            if (platformIndex == 4)
            {
                Instantiate(boostPlat, posXY, Quaternion.identity);
            }

            //range in which platforms are spawning to each other
            y += Random.Range(1.5f, 2.5f);
            
        }
        //Avoid that platforms am repeating when new platforms have to be generated
        platformSpace = spawnPoint;
    }

}
