using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyerScript : MonoBehaviour
{

    private GameObject platformEndPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformEndPoint = GameObject.Find("PlatformEndPoint");        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformEndPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
