using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //Work in progress on this script - not perfectly working

    public Transform Background1;
    public Transform Background2;


    private bool Whichone = true;

    public Transform cam;

    private float currentHeight = 22.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHeight < cam.position.y)
        {
            //moves the background sprites to the position of the player
            if (Whichone)
            {
                Background1.localPosition = new Vector3(0, Background1.localPosition.y + 30, 0);
            }
            else
            {
                Background2.localPosition = new Vector3(0, Background2.localPosition.y + 30, 0);
            }
            currentHeight += 22.5f;
            Whichone = !Whichone;

        }
    }
}
