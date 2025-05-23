using UnityEngine;

public class RespawnOnCollision : MonoBehaviour
{
    public Transform respawnPoint; // Last checkpoint reached

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Map"))
        {
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
                Debug.Log("Player hit the map and was respawned.");
            }
        }
    }

    public void SetRespawnPoint(Transform checkpoint)
    {
        respawnPoint = checkpoint;
    }
}
