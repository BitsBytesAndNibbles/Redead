using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public SpriteRenderer spriteRenderer;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", movement.sqrMagnitude);
        if (movement.x < 0 && !spriteRenderer.flipX || movement.x > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        
    }

    void FixedUpdate()
    {
        //move
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //attack
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {

            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
