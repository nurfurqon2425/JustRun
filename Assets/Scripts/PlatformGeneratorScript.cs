using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorScript : MonoBehaviour
{

    public Transform platformPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

    private float[] platformWidths;
    public ObjectPooler[] platformPoolers;

    private ItemGeneratorScript itemGenerator;

    // Start is called before the first frame update
    void Start()
    {
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;

        platformWidths = new float[platformPoolers.Length];
        for(int i = 0; i < platformPoolers.Length; i++)
        {
            platformWidths[i] = platformPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        itemGenerator = FindObjectOfType<ItemGeneratorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformPoint.position.x)
        {
            int random = Random.Range(0, platformPoolers.Length);
            float distance = platformWidths[random] / 2;

            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);

            transform.position = new Vector3(transform.position.x + distance + gap, height, transform.position.z);

            GameObject platform = platformPoolers[random].GetPooledGameObject();
            platform.transform.position = transform.position;
            platform.SetActive(true);

            itemGenerator.SpawnApple(transform.position, platformWidths[random]);

            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }    

        
    }
}
