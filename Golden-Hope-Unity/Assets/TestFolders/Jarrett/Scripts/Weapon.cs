using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D hitbox;
    public Collision2D collision;
    public int knockbackDist;
    public Vector2 knockbackForce;
    public WeaponHitBox weaponHitBox;

    public int Damage;

    public Enemy EnemyController;
    public Combat PlayerController;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponHitBox.gameObject.SetActive(false);
        Damage = 1;
    }

    public void Swing()
    {
        StartCoroutine(SwingCo());       
    }

    private IEnumerator SwingCo()
    {
        weaponHitBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        weaponHitBox.gameObject.SetActive(false);
    }

    public void ApplyDamage(Enemy enemyToHurt)
    {
        EnemyController = enemyToHurt;
        enemyToHurt.TakeDamage(Damage, transform.position);
        print("Take that, enemy!");
    }
}