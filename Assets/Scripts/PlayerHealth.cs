using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used to reset scene when Player dies

public class PlayerHealth : MonoBehaviour
{   
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    [SerializeField] private int maxArmor;
    [SerializeField] private int armor;

    void Start()
    {
        health = maxHealth;
        armor = maxArmor;
    }

    void Update()
    {
        
    }

    public void DamagePlayer (int damage)
    {
        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                int remainingDamage;

                remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;  
        }

        if (health <= 0)
        {   
            // Reloads scene when Player dies
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
