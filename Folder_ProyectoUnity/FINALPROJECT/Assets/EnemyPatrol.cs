using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private bool forward = true;

    private Transform player;
    private bool playerDetected = false;

    void Start()
    {


        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0 || playerDetected)
        {
            return;
        }

        Vector3 targetPosition = points[destPoint].position;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);

        // Check if reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (forward)
            {
                destPoint++;
                if (destPoint >= points.Length)
                {
                    destPoint = points.Length - 1;
                    forward = false;
                }
            }
            else
            {
                destPoint--;
                if (destPoint < 0)
                {
                    destPoint = 0;
                    forward = true;
                }
            }
        }
    }

    void Update()
    {
        if (!playerDetected)
        {
            GotoNextPoint();
        }
        else if (player != null)
        {
            Vector3 playerPosition = player.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}

