using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
        }
    }
    
    public void TakeDamage(int damage)
    {
        
        health -= damage;

        Debug.Log("damage TAKEN!");
    }
}
