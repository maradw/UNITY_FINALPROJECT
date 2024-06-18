using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using DG.Tweening;
public class NPCNavMovement : MonoBehaviour
{

    [SerializeField] private Transform[] patrolPoints;

    private int currentPoint = 0;

    [SerializeField] private NavMeshAgent _patrolNPC;

    private void Start()
    {
        _patrolNPC.SetDestination(patrolPoints[currentPoint].position);
    }

    void NPCMovement()
    {
        if (_patrolNPC.remainingDistance <= _patrolNPC.stoppingDistance)
        {
            currentPoint++;
            if (currentPoint == patrolPoints.Length)
            {
                currentPoint = 0;
            }
            _patrolNPC.SetDestination(patrolPoints[currentPoint].position);
        }
    }
    IEnumerator StopMovement()
    {
        _patrolNPC.Stop();

        yield return new WaitForSeconds(3f);

    }
    IEnumerator ContinueMovement()
    {
        _patrolNPC.Resume();

        yield return new WaitForSeconds(3f);
    }
    public void CallInteract()
    {
        StartCoroutine(StopMovement());
       // StartCoroutine(ContinueMovement());
    }

    void Update()
    {
        NPCMovement();
    }

}
