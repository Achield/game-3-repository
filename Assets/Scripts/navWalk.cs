using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navWalk : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            agent.destination = movePositionTransform.position;
        }
    }


}
