using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawningScriptDungeon : MonoBehaviour
{
    // Item 1 - Orange - Heals Players by decereasing 30% of their PD
    public GameObject itemPrefabs;
    public float itemSpawnTime;

    // Item 2 - First Aid Kit - Heals Players back down to 0%
    public GameObject itemPrefabs2;
    public float itemSpawnTime2;

    // Item 3 - Magical Can - Increase MP level faster by 30 for the players
    public GameObject itemPrefabs3;
    public float itemSpawnTime3;

    // Item 4 - Bad Orange - Poisons players by increasing 50% of their PD 
    public GameObject itemPrefabs4;
    public float itemSpawnTime4;


    void Start()
    {
        itemSpawnTime = Random.Range(10, 30);
        itemSpawnTime2 = Random.Range(60, 120);
        itemSpawnTime3 = Random.Range(10, 30);
        itemSpawnTime4 = Random.Range(20, 40);



    }

    void Update()
    {
        // Decreasing item spawn time by time before it appears on the stage
        itemSpawnTime -= Time.deltaTime;
        itemSpawnTime2 -= Time.deltaTime;
        itemSpawnTime3 -= Time.deltaTime;
        itemSpawnTime4 -= Time.deltaTime;

        if (itemSpawnTime <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-13.7f, 15.1f), 0.4f, -6.37f);
            Instantiate(itemPrefabs, randomSpawnPosition, Quaternion.identity);
            itemSpawnTime = Random.Range(10, 30);
        }

        if (itemSpawnTime2 <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-13.7f, 15.1f), 0.4f, -6.37f);
            Instantiate(itemPrefabs2, randomSpawnPosition, Quaternion.identity);
            itemPrefabs2.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            itemSpawnTime2 = Random.Range(60, 120);
        }

        if (itemSpawnTime3 <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-13.7f, 15.1f), 0.4f, -6.37f);
            Instantiate(itemPrefabs3, randomSpawnPosition, Quaternion.identity);
            itemSpawnTime3 = Random.Range(10, 30);
        }
        if (itemSpawnTime4 <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-13.7f, 15.1f), 0.4f, -6.37f);
            Instantiate(itemPrefabs4, randomSpawnPosition, Quaternion.identity);
            itemSpawnTime4 = Random.Range(20, 40);
        }
    }
}
