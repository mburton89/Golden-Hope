using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FloorManager.NextFloor();
        }
    }
}
