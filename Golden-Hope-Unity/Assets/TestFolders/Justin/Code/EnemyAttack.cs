using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float startTimeBetweenAttack;
    private float timeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    public int damage;
    public bool willAttack = true;
    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (willAttack)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<CharacterControl>().TakeDamage(damage);
                }
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
