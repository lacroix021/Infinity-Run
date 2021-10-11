using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public BoxCollider2D colActivator;
    public LayerMask layerPlayer;
    public bool activate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activate = Physics2D.IsTouchingLayers(colActivator, layerPlayer);

        if (activate)
        {
            StartCoroutine(Timing());
        }
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
