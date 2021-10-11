using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGround : MonoBehaviour
{
    public float speed;
    public float timeDestroySlow = 10;
    public float timeDestroyfast = 5;

    public bool fastGame;
    GameManager gManager;

    /*
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
        if (!fastGame)
            Destroy(this.gameObject, timeDestroySlow);
        else
            Destroy(this.gameObject, timeDestroyfast);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && gManager.fastGame)
        {
            speed = 6;
        }
    }
    */
}
