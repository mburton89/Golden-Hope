using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharge : EnemyAttackAI
{
    public GameObject test;

    public override void Attack()
    {
        Debug.Log("Start Attack");
        StartCoroutine(Charge());
    }

    private IEnumerator Charge()
    {
        Enemy e = this.GetComponent<Enemy>();
        e.move = 0f;
        e.movementOverride = true;
        yield return new WaitForSeconds(2f);

        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        

        Transform t = e.player;
        Vector2 v2 = new Vector2(t.position.x, t.position.y);

        Instantiate(test, t.position, Quaternion.identity);

        Vector2 dir = new Vector2(v2.x - e.gameObject.GetComponent<Transform>().position.x, v2.y - e.gameObject.GetComponent<Transform>().position.y);
        dir.Normalize();
        rb.AddForce(dir * 200);

        //rb.MovePosition((Vector2)transform.position + (v2 * 10f * Time.deltaTime));

        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        e.movementOverride = false;
    }
}
