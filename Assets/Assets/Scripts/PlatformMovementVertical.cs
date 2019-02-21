using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementVertical : MonoBehaviour
{
    [SerializeField]
    private float platformSpeed = 1f;
    private bool endPoint;

    public float endPointY;
    public float startPoint;

    public int unitsToMove = 2;

    private void Start()
    {
        startPoint = transform.position.y;

        endPointY = startPoint + unitsToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (endPoint)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }

        if (transform.position.y >= endPointY)
        {
            endPoint = false;
        }
        if (transform.position.y <= startPoint)
        {
            endPoint = true;
        }
    }
}
