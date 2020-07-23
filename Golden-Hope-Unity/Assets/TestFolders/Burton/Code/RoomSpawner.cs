using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 == need bottom door
    // 2 == need top door
    // 3 == need left door
    // 4 == need right door

    private RoomTemplates _roomTemplates;
    private int rand;
    [HideInInspector] public bool spawned;

    private void Start()
    {
        spawned = false;
        _roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .25f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //spawn room with BOTTOM door
                rand = Random.Range(0, _roomTemplates.bottomRooms.Length);
                Instantiate(_roomTemplates.bottomRooms[rand], transform.position, _roomTemplates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with TOP door
                rand = Random.Range(0, _roomTemplates.topRooms.Length);
                Instantiate(_roomTemplates.topRooms[rand], transform.position, _roomTemplates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //spawn room with LEFT door
                rand = Random.Range(0, _roomTemplates.leftRooms.Length);
                Instantiate(_roomTemplates.leftRooms[rand], transform.position, _roomTemplates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with RIGHT door
                rand = Random.Range(0, _roomTemplates.rightRooms.Length);
                Instantiate(_roomTemplates.rightRooms[rand], transform.position, _roomTemplates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hello");
        if (collision.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
