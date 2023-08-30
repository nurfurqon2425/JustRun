using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorScript : MonoBehaviour
{

    public ObjectPooler applePooler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnApple(Vector3 position, float platformWidth)
    {
        int random = Random.Range(1, 100);

        if (random < 50)
            return;

        int numberOfApples = (int)Random.Range(3f, platformWidth);

        float x = position.x - (platformWidth / 2) + 1;
        float y = position.y + Random.Range(2, 4);

        for(int i = 0; i < numberOfApples; i++)
        {
            GameObject apple = applePooler.GetPooledGameObject();

            apple.transform.position = new Vector3(x + i, y, 0);

            apple.SetActive(true);
        }


    }    
}
