using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickerScript : MonoBehaviour
{
    private AudioSource itemPickSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            if (itemPickSound.isPlaying) 
            {
                itemPickSound.Stop();
            }
            itemPickSound.Play();
        }    
    }
}
