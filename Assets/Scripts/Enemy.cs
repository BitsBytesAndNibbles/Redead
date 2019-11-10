using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathExplosion;

	private Animator animator;
    public SpriteRenderer spriteRenderer;
	private AIPath enemy;

    public Transform attackPos;
    public float attackRange;
    public LayerMask playersToHit;
    public int damage;

    // Start is called before the first frame update
    void Start()
    { 
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
            attackPos.localPosition = new Vector2(attackPos.localPosition.x * -1, attackPos.localPosition.y);
        }

		
    }
    
    public void TakeDamage(int damage)
    {

        health -= damage;
        if (health <= 0)
        {
            GameObject particle = Instantiate(deathExplosion, transform);
            animator.SetBool("dead", true);
            Destroy(gameObject, 1f);
        } else
        {
            animator.SetTrigger("hit");
        }

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		Debug.Log(collision.name);
		if (collision.tag == "Player")
		{
			animator.SetBool("attack", false);
		}
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
