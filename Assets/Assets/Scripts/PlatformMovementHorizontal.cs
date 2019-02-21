using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementHorizontal : MonoBehaviour
{
    //Vertical and Horizontal classes will be put together later

    [SerializeField]
    private float platformSpeedHorizontal = 1f;
    [SerializeField]
    private float startPoint;
    [SerializeField]
    private bool endPoint;
    [SerializeField]
    private float endPointX;
    [SerializeField]
    private int unitsToMove = 2;

    private void Start()
    {
        //sets the starting position
        startPoint = transform.position.x;

        //endposition 
        endPointX = startPoint + unitsToMove;
    }

    // Update is called once per frame
    void Update()
    {
            //If the enpoint is reached (max units to move) the platform moves right
            if (endPoint)
            {
                transform.position += Vector3.right * platformSpeedHorizontal * Time.deltaTime;
            }
            //If the enpoint is reached (max units to move) the platform moves right
            else
            {
                transform.position -= Vector3.right * platformSpeedHorizontal * Time.deltaTime;
            }
            //look if endpoint is reached
            if (transform.position.x >= endPointX)
            {
                endPoint = false;
            }
            if (transform.position.x <= startPoint)
            {
                endPoint = true;
            }
        }
        
    }