using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float startTimeBetweenAttack;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public LayerMask whatIsPlayer;
    public int damage;

    public float bulletForce = 20f;

    private float timeBetweenAttack;

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            Attack();
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
