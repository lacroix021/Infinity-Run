using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("OBJETOS A SPAWNEAR")]
    public GameObject[] objects;
    
    GameObject instance;

    [Header("PUNTOS SPAWN")]

    public Transform[] spawns;


    public float spawnRate;
    float nextSpawnTime;

    int num;
    int numB;

    GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        NumberSpawn();
    }

    void NumberSpawn()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (!gManager.fastGame)
                spawnRate = Random.Range(0.5f, 1.2f);
            else
                spawnRate = Random.Range(1.0f, 2.0f);

            SpawnObstacles();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }


    void SpawnObstacles()
    {
        num = Random.Range(0, 2); // 0 para A, 1 para B, 2 para C

        if (num == 0)
        {
            SwitchItems();
            Instantiate(instance, new Vector3(spawns[0].position.x, spawns[0].position.y, 0), Quaternion.identity);
        }
        else if(num == 1)
        {
            SwitchItems();
            Instantiate(instance, new Vector3(spawns[1].position.x, spawns[1].position.y, 0), Quaternion.identity);
        }
    }


    void SwitchItems()
    {
        numB = Random.Range(0, 2);

        if(numB == 0)
        {
            instance = objects[0];
        }
        else if(numB == 1)
        {
            instance = objects[1];
        }

        num = 0;
    }
}
