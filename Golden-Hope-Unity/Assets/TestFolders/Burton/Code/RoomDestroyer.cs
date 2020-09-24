using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room" || collision.tag == "SpawnPoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
