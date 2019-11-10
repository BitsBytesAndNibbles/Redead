using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFXController : MonoBehaviour
{
    private AIPath enemy;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(enemy.currentDir[0]));
        if (enemy.currentDir[0] < 0 && !spriteRenderer.flipX || enemy.currentDir[0] > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("attack", false);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hit");
        health -= damage;
        animator.SetBool("hit", true);
    }

}
