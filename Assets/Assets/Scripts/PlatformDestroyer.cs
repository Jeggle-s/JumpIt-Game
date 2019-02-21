using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject destroyPlatform;

	// Use this for initialization
	void Start ()
    {
        destroyPlatform = GameObject.Find("DestroyPlatform");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < destroyPlatform.transform.position.y)
        {
            Destroy(gameObject);
        }
		
	}
}
