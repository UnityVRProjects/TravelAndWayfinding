using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    public Transform respawnPoint; // Last checkpoint reached
                                   // public Transform xrCamera;
    private Rigidbody rb;
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
                Quaternion forwardRotation = Quaternion.Euler(0, respawnPoint.eulerAngles.y, 0);
                transform.rotation = forwardRotation;
                // Quaternion worldForward = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                // transform.rotation = worldForward;


                // Vector3 cameraForwardFlat = new Vector3(xrCamera.forward.x, 0, xrCamera.forward.z).normalized;
                // float angleToForward = Vector3.SignedAngle(cameraForwardFlat, Vector3.forward, Vector3.up);

                // // Step 3: Apply a rotation in the opposite direction so the camera faces forward
                // transform.Rotate(Vector3.up, angleToForward);

                Debug.Log("Player hit the map and was respawned.");
            }
        }
    }

    public void SetRespawnPoint(Transform checkpoint)
    {
        respawnPoint = checkpoint;
    }
}
