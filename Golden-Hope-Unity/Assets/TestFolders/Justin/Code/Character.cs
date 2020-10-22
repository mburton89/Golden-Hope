using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    //public float moveSpeed;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage taken: " + damage.ToString());
    }
}
