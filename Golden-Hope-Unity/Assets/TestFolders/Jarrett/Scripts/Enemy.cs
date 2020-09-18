using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider EnemyHP;
    public Vector3 Offset;

    public int EnemyMaxHP;
    public int EnemyCurrentHP;
    public int EnemyDamage;

    public void Start()
    {
        EnemyCurrentHP = EnemyMaxHP;
        EnemyHP.maxValue = EnemyMaxHP;
        EnemyHP.value = EnemyCurrentHP;
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
}
