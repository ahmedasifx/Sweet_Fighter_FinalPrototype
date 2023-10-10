using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;

    public float moveSpeed;
    public float attackDistance;
    public float attackCooldown;

    private bool isAttacking;
    private bool canAttack = true;

    private Transform target;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= attackDistance)
        {
            if (!isAttacking && canAttack)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb2d.velocity = direction * moveSpeed;
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        canAttack = false;

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
        isAttacking = false;
    }


  
}
