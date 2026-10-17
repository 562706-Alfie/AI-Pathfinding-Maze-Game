using System;
using UnityEngine;
using UnityEngine.AI;

// This script makes the enemy move towards the player

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform targetPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetPosition = GameObject.Find("Target Position").transform;
    }

    private void Update()
    {
        navMeshAgent.destination = targetPosition.position;
    }
}
