using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GroundPiece") || col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}
