using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public ParticleSystem deathEffect;
    public ParticleSystem deathExplosion;
	private Animator animator;
    public SpriteRenderer spriteRenderer;
	private AIPath enemy;
    public Transform enemyAttackPos;
    public float attackRange;

	// Start is called before the first frame update
	void Start()
    {
        deathExplosion = GetComponent<ParticleSystem>();
		animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		enemy = GetComponentInParent<AIPath>();
	}

	// Update is called once per frame
	void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(enemy.currentDir[0]));
		if (enemy.currentDir[0] < 0 && !spriteRenderer.flipX || enemy.currentDir[0] > 0 && spriteRenderer.flipX)
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
            enemyAttackPos.localPosition = new Vector2(enemyAttackPos.localPosition.x * -1, enemyAttackPos.localPosition.y);
        }

        
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("dead", true);
            Destroy(gameObject, 1f);
        } else
        {
            animator.SetTrigger("New Trigger");
        }
        
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			animator.SetBool("attack", false);
		}
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyAttackPos.position, attackRange);
    }
}
