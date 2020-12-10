using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntrance : MonoBehaviour
{
    public GameObject[] rooms;
    private bool overlap;
    private bool fixedEntrance;

    private void Start()
    {
        StartCoroutine(CheckOverlap());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RoomEntrance")
        {
            overlap = true;
        }
        rooms[0].GetComponent<InRoomManager>().ActivateRoom();
    }

    private void UpdatePlayerRoom()
    {

    }

    private IEnumerator CheckOverlap()
    {
        yield return new WaitForSeconds(0.01f);
        if (overlap)
        {
            if (!fixedEntrance)
            {
                Destroy(this);
            }
        }
        else
        {
            fixedEntrance = true;
        }
    }
}
