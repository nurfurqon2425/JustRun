using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new List<GameObject>();

        for(int i = 0; i < numberOfObject; i++)
        {
            GameObject gameObject = Instantiate(pooledObject);
            gameObject.SetActive(false);
            gameObjects.Add(gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledGameObject()
    {
        foreach(GameObject gameObj in gameObjects)
        {
            if(!gameObj.activeInHierarchy)
            {
                return gameObj;
            }
        }

        GameObject gameObject = Instantiate(pooledObject);
        gameObject.SetActive(false);
        gameObjects.Add(gameObject);
        return gameObject;
    }   
}
