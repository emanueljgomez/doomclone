using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float range  = 20f;
    [SerializeField] private float verticalRange = 20f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextTimeToFire;
    [SerializeField] private float damage = 1f;

    [SerializeField] private BoxCollider gunTrigger;    
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private LayerMask raycastLayerMask; // Raycast will ignore the 'Gun' layer, but will affect the 'Default' layer

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Damages all enemies inside the 'enemiesInTrigger' list
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {   
            var dir = enemy.transform.position - transform.position; // Obtains firing direction based on player and enemy positions
            RaycastHit hit;

            // If raycast hits enemy, then take damage
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {   
                    // Range check: if enemy is too far, it will take less damage
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        enemy.TakeDamage(damage);
                    }
                    else
                    {
                        enemy.TakeDamage(damage * 2);
                    }
                }
            }
            
        }

        // Resets attack timer
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detects potential enemy to shoot (Aim assist)
        Enemy enemy = other.transform.GetComponent<Enemy>(); // Gets 'Enemy' script component from Enemy object

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Removes enemy from detection
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
