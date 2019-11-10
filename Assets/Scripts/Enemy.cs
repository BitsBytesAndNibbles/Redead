using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathExplosion;
    public GameObject impactExplosion;


    private Animator animator;
    public SpriteRenderer spriteRenderer;
	private AIPath enemy;

    private bool facingLeft;

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
		if (enemy.currentDir[0] < 0 && !facingLeft || enemy.currentDir[0] > 0 && facingLeft)
		{
            facingLeft = !facingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject particle = Instantiate(deathExplosion, transform);
            animator.SetBool("dead", true);
            Destroy(particle, 1f);
            Destroy(gameObject, 1f);
        } else
        {
            GameObject particle = Instantiate(impactExplosion, transform);
            Destroy(particle, 1f);
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
}
