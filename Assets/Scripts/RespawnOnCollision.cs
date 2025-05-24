using System.Collections.Generic;
using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    public Transform respawnPoint; // Last checkpoint reached
                                   // public Transform xrCamera;
    private Rigidbody rb;
    public Stopwatch stopwatch;
    public List<Transform> checkpointList;
    private int currentCheckpointIndex = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with: {collision.gameObject.name}");
        if (collision.collider.CompareTag("Map"))
        {
            Debug.Log("Found map");
            if (respawnPoint != null)
            {

                // Disable velocity and angular momentum
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Setting position and orientation for respawning
                transform.position = respawnPoint.position;
                // Quaternion forwardRotation = Quaternion.Euler(0, respawnPoint.eulerAngles.y, 0);
                // transform.rotation = forwardRotation;
                // Quaternion worldForward = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                // transform.rotation = worldForward;

                if (stopwatch != null)
                {
                    stopwatch.AddPenalty();
                    Debug.Log("Added penalty after hitting the map.");
                }

                 // Face the next checkpoint (or stay at current if last)
                int nextIndex = Mathf.Min(currentCheckpointIndex + 1, checkpointList.Count - 1);
                Vector3 directionToNext = checkpointList[nextIndex].position - respawnPoint.position;
                //directionToNext.y = 0; // ignore vertical rotation

                if (directionToNext != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(directionToNext);
                    transform.rotation = lookRotation;
                }

                Debug.Log("Player hit the map and was respawned.");
            }
        }
    }

    public void SetRespawnPoint(Transform checkpoint, int checkpointIndex)
    {
        respawnPoint = checkpoint;
        currentCheckpointIndex = checkpointIndex;
    }
}
