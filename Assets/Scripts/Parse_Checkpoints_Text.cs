using UnityEngine;
using System.Collections.Generic;

public class FileParser : MonoBehaviour
{
    public TextAsset file;
    public Material checkpointMaterial;
    public float sphereRadius = 1.5f;
    public float checkpointTriggerRadius = 9.144f;

    private LineRenderer lineRenderer;
    public GameObject xrOrigin;
    public Material reachedMaterial;

    //private Stopwatch stopwatch;

    void Start()
    {
        List<Vector3> positions = ParseFile();
        if(positions.Count > 0){
            if (xrOrigin != null){
                xrOrigin.transform.position = positions[0];
            }
        }
        if(positions.Count > 1){
            if(xrOrigin != null){
                Vector3 direction = positions[1] - positions[0];
                Quaternion nextCheckpointDirection = Quaternion.LookRotation(direction);
                xrOrigin.transform.rotation = nextCheckpointDirection;
            }
        }
        //stopwatch.StartCheckpoint(positions.Count);
        DrawCheckpoints(positions);
    }

    List<Vector3> ParseFile()
    {
        List<Vector3> positions = new List<Vector3>();
        float scaleFactor = .0254f;
        string content = file.text;
        string[] lines = content.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string[] coords = lines[i].Trim().Split(' ');
            if (coords.Length >= 3)
            {
                float x = float.Parse(coords[0]);
                float y = float.Parse(coords[1]);
                float z = float.Parse(coords[2]);
                Vector3 scaledPos = new Vector3(x, y, z) * scaleFactor;
                positions.Add(scaledPos);
            }
        }

        return positions;
    }

    void DrawCheckpoints(List<Vector3> positions)
    {   
        GameObject lineObj = new GameObject("CheckpointPath");
        lineObj.transform.parent = this.transform;

        lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Count;
        lineRenderer.material = checkpointMaterial;
        lineRenderer.widthMultiplier = 0.3f;
        // lineRenderer.SetPosition(0,XROrigin);
        for (int i = 0; i < positions.Count; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = positions[i];
            sphere.transform.localScale = Vector3.one * sphereRadius * 2f;
            sphere.name = $"Checkpoint_{i + 1}";

            if (checkpointMaterial != null)
            {
                Renderer renderer = sphere.GetComponent<Renderer>();
                renderer.material = checkpointMaterial;
            }

            // Adds the checkpoint interaction code
            Checkpoint cp = sphere.AddComponent<Checkpoint>();
            cp.reachedMaterial = reachedMaterial;
            cp.player = xrOrigin.transform;
            cp.triggerDistance = checkpointTriggerRadius;
            //cp.stopwatchInCP = stopwatch;

            sphere.transform.parent = this.transform;

            lineRenderer.SetPosition(i,positions[i]);

        }
    }
}