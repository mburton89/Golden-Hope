using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    public float startTimeBetweenAttack;
    private float timeBetweenAttack;

    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    public int damage;
    public bool willAttack = true;

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (!willAttack)
            {
                willAttack = true;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    public void CheckAttack()
    {
        if (willAttack)
        {
            Attack();
            willAttack = false;
            timeBetweenAttack = startTimeBetweenAttack;
        }

    }

    public virtual void Attack()
    {
        Debug.Log("No Attack AI");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
