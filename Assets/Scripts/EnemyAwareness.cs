using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool isAggro;
    
    [SerializeField] private Material aggroMat;

    void Update()
    {
        // Changes enemy color to identify aggroed enemy
        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        // Sets enemy aggro to true if player comes too close
        if (other.transform.CompareTag("Player"))
        {
            isAggro = true;            
        }
    }
}
