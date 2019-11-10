using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public ParticleSystem deathEffect;
    public ParticleSystem deathExplosion;
    // Start is called before the first frame update
    void Start()
    {
        deathExplosion = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            deathEffect.Emit(50);
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        
        health -= damage;

        Debug.Log("damage TAKEN!");
    }
}
