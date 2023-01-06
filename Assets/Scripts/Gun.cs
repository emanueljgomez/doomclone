using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float range  = 20f;
    [SerializeField] private float verticalRange = 20f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextTimeToFire;
    [SerializeField] private float damage = 2f;

    [SerializeField] private BoxCollider gunTrigger;
    
    [SerializeField] private EnemyManager enemyManager;

    void Start()
    {
        InitializeGunTrigger();
    }

    void Update()
    {
        checkForPlayerAttack();
    }

    void InitializeGunTrigger()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    void checkForPlayerAttack()
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
            enemy.TakeDamage(damage);
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
