using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
            if (collision.tag == "Player")
            {
                //CharacterStats cs = collision.GetComponent<CharacterStats>();
                if (CharacterStats.armor > 0)
                {
                    CharacterStats.armor--;
                }
                else
                {
                    CharacterStats.health -= 2;
                }
            }
        }
    }
}
