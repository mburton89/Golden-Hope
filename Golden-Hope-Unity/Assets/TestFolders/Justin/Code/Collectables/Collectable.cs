using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CircleCollider2D cc;
    private GameObject player;
    public bool equip = false;
    public bool readyToEquip = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!equip)
        {
            if (collision.tag == "Player")
            {
                Collect();
                Destroy(gameObject);
                player.GetComponent<CharacterStats>().Instance.ChangeText();
            }
        }
        else
        {
            if (collision.tag == "Player")
            {
                readyToEquip = true;
            }
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Collect();
            Destroy(gameObject);
            player.GetComponent<CharacterStats>().Instance.ChangeText();
        }
    }*/

    public virtual void Collect()
    {
        Debug.Log("Default Collectable");
    }
}
