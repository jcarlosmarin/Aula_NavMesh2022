using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent myAgent;

    private float maxRange = 20f;

    void Start()
    {
        myAgent.SetDestination(GetRandomPosition(maxRange));
    }

    void Update()
    {
        if (myAgent.remainingDistance < 0.5)
        {
            myAgent.SetDestination(GetRandomPosition(maxRange));
        }
    }

    Vector3 GetRandomPosition(float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;

        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, range, 1);
        Vector3 finalPosition = hit.position;

        return finalPosition;
    }
}
