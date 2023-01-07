using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyAwareness enemyAwareness;
    [SerializeField] private Transform playersTransform;
    [SerializeField] private UnityEngine.AI.NavMeshAgent enemyNavMeshAgent;

    void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {   
        if (enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        }
        else
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        }
    }
}
