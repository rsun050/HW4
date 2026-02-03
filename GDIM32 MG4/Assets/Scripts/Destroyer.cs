using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Pipe"))
        {
            // Debug.Log("destroy a pipe");
            Destroy(col.gameObject);
        }
    }
}
