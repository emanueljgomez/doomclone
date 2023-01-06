using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] private float enemyHealth = 2f;

    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private GameObject gunHitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkEnemyHealth();
    }

    public void TakeDamage( float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }

    void checkEnemyHealth()
    {
        if (enemyHealth <= 0)
        {   
            enemyManager.RemoveEnemy(this); // At death, enemy is removed from the list that contains enemies "in sight"
            Destroy(gameObject);
        }
    }
}
