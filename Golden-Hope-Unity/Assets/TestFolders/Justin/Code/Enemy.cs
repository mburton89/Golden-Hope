using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    enum State
    {
        Wander,
        Follow,
        Attack,
        Dead
    };

    public bool active = false;
    public Transform player;
    public float moveSpeed = 5f;
    public float attackRange = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private State state;

    private EnemyAttackAI attackAI;

    public float move;

    public bool movementOverride = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        attackAI = this.GetComponent<EnemyAttackAI>();
        state = State.Follow;
        move = moveSpeed;
        if (!active)
        {
            enabled = false;
        }
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Vector3 direction = player.position - transform.position;
        float _distanceToPlayer = direction.magnitude;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        switch (state)
        {
            case State.Follow:
                {
                    move = moveSpeed;
                    movement = direction;

                    //Debug.Log(_distanceToPlayer);
                    if (_distanceToPlayer < attackRange)
                    {
                        state = State.Attack;
                    }
                    break;
                }
            case State.Attack:
                {
                    Attack(_distanceToPlayer);
                    break;
                }
            default:
                {
                    break;
                }


        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        if (!movementOverride)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * move * Time.deltaTime));
    }

    public virtual void Attack(float distanceToPlayer)
    {
        //move = 0f;
        print("I SUMMON GENERIC ENEMY, IN ATTACK MODE!!");
        /*
            this is where the enemy would attack
        */
        attackAI.CheckAttack();
        if (distanceToPlayer > attackRange)
        {
            state = State.Follow;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().TakeDamage(2);
        }
    }

    public void PrintTarget()
    {
        Debug.Log(player.position);
    }
}
