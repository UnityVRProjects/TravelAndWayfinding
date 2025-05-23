using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material reachedMaterial;
    public float triggerDistance = 9.144f;
    public Transform player;
    private bool reached;
    //public Stopwatch stopwatchInCP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!reached && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= triggerDistance)
            {
                reached = true;
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null && reachedMaterial != null)
                {
                    renderer.material = reachedMaterial;
                    // if(stopwatchInCP != null){
                    //     stopwatchInCP.CheckpointReached();
                    // }
                }

                Debug.Log($"{gameObject.name} reached!");
            }
        }
    }
}
