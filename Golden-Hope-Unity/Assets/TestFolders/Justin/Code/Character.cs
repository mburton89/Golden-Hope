using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    public int maxHealth;
    //public float moveSpeed;

    public void TakeDamage(int damage)
    {
        Debug.Log("damage taken: " + damage.ToString());

        if (this.gameObject.tag == "Player")
        {
            if (CharacterStats.armor > 0)
            {
                CharacterStats.armor--;
            }
            else
            {
                CharacterStats.health -= 2;
            }
        }
        else
        {
            health -= damage;
        }
    }
}
