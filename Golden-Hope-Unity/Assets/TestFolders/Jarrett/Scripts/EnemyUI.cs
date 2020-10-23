using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider EnemyHP;
    public Vector3 Offset;
    public Collider2D EnemyCollider;
    public Collision2D EnemyHitBox;

    public int EnemyMaxHP;
    public int EnemyCurrentHP;
    public int EnemyDamage;

    private Rigidbody2D _rigidbody2D;

    public void Start()
    {
        EnemyCurrentHP = EnemyMaxHP;
        EnemyHP.maxValue = EnemyMaxHP;
        EnemyHP.value = EnemyCurrentHP;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyHP.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
        UpdateEnemyHealth();
        if(EnemyCurrentHP == 0)
        {
            EnemyDeath();
        }
    }

    public void UpdateEnemyHealth()
    {
        if(EnemyCurrentHP != EnemyHP.value)
        {
            EnemyHP.value = EnemyCurrentHP;
        }
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageToTake, Vector3 positionOfDamager)
    {
        //Take away HP
        EnemyCurrentHP = EnemyCurrentHP - damageToTake;

        //Knock back the boy
        Vector3 directionToKnockBack = transform.position - positionOfDamager;
        _rigidbody2D.AddForce(directionToKnockBack * (damageToTake * 100));
    }
}
