using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public ParticleSystem deathExplosion;
    public GameObject explosionPE;

	private Animator animator;
    public SpriteRenderer spriteRenderer;
	private AIPath enemy;

    private void Awake()
    {
    }
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
		}

		if (health <= 0)
        {
            //StartCoroutine(Break());
            GameObject particle = Instantiate(explosionPE, transform);
            Destroy(gameObject, 0.5f);
            Destroy(particle, 1f);
        }
    }
    
    public void TakeDamage(int damage)
    {
        
        health -= damage;

        Debug.Log("damage TAKEN!");
    }

    private IEnumerator Break()
    {
        yield return new WaitForSeconds(1);
        GameObject particle = Instantiate(explosionPE, transform);
        Destroy(gameObject);
        Destroy(particle, 1f);
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
