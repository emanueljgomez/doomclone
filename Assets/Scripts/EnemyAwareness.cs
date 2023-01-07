using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool isAggro;
    [SerializeField] private float awarenessRadius = 8f;
    
    [SerializeField] private Material aggroMat;
    [SerializeField] private Transform playersTransform;

    void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        // Sets enemy aggro to true if player comes too close
        if (dist < awarenessRadius)
        {
            isAggro = true;
        }
        
        // Changes enemy color to identify aggroed enemy
        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }
}
