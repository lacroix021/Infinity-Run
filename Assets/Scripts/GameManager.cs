using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool fastGame;

    [Header("VELOCIDAD DE Jugador")]
    public float speedSlow;
    public float speedFast;

    [Header("VELOCIDAD DE BLOQUES PISO")]
    public float speedBlockSlow;
    public float speedBlockFast;

    [Header("PREFAB PARA EL PISO")]
    public GameObject pieceGround;
    GameObject instance;

    Player player;
    Transform playerPos;


    BoxCollider2D myCollider;
    public LayerMask layerGround;
    public bool hayPiso;

    float nextSpawnTime;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RelocatePlayer();
        SpawnGround();
    }

    void RelocatePlayer()
    {
        if (!fastGame)
        {
            player.moveSpeed = speedSlow;
            player.FastGame = false;
        }
        else
        {
            player.moveSpeed = speedFast;
            player.FastGame = true;
        }

    }

    void SpawnGround()
    {
        hayPiso = Physics2D.IsTouchingLayers(myCollider, layerGround);

        if (!hayPiso)
        {
            if (Time.time >= nextSpawnTime)
            {
                instance = Instantiate(pieceGround, transform.position, Quaternion.identity);
                instance.name = pieceGround.name;
                nextSpawnTime = Time.time + 1f / spawnRate;
            }
        }
    }
}
