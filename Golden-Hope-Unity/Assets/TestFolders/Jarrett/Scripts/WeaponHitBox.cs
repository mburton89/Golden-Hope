using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    private Weapon _controller;

    private void Start()
    {
        _controller = GetComponentInParent<Weapon>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected" + other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy in Range");
            _controller.ApplyDamage(other.gameObject.GetComponent<Enemy>());
        }
    }
}
