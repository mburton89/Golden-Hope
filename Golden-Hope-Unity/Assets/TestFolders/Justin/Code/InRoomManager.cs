using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoomManager : MonoBehaviour
{
    public string typeOfRoom;

    public GameObject[] eligableRooms;
    public bool startingRoom = false;

    public GameObject[] enemiesInRoom;

    private void Start()
    {
        if (!startingRoom)
        {
            GameObject _layout = Instantiate(eligableRooms[(int)Random.Range(0, eligableRooms.Length)], this.gameObject.transform.position, Quaternion.identity);
            RoomLayout _rm = _layout.GetComponent<RoomLayout>();
            int _enemyCount = _rm.enemies.Length;
            enemiesInRoom = new GameObject[_enemyCount];
            for (int _i = 0; _i < _enemyCount; _i++)
            {
                enemiesInRoom[_i] = _rm.enemies[_i];
            }
        }
    }

    public void ActivateRoom()
    {
        int _count = enemiesInRoom.Length;
        for (int _j = 0; _j < _count; _j++)
        {
            if (enemiesInRoom[_j])
            {
                enemiesInRoom[_j].GetComponent<Enemy>().enabled = true;
                enemiesInRoom[_j].GetComponent<Enemy>().PrintTarget();
            }
        }
    }
}
