using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Stopwatch : MonoBehaviour
{
    // public TextMeshProUGUI stopwatchText;
    // public float elapsedTime = 0f;
    // public bool stopwatchRunning = false;
    // private int totalCheckpoints;
    // private int checkpointsReached = 0;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     stopwatchText.fontSize = 80;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(stopwatchRunning){
    //         elapsedTime += Time.deltaTime;
    //         stopwatchText.text = FormatTime(elapsedTime);
    //     }
    // }

    // public void StartCheckpoint(int numCheckpoints){
    //     totalCheckpoints = numCheckpoints;
    //     stopwatchRunning = true;
    //     //reset checkpoint counts
    //     checkpointsReached = 0;
    //     elapsedTime = 0f;
    // }

    // public void CheckpointReached(){
    //     checkpointsReached++;
    //     if(checkpointsReached >= totalCheckpoints){
    //         stopwatchRunning = false;
    //         stopwatchText.fontSize = 120;
    //     }
    // }
    // string FormatTime(float t)
    // {
    //     int minutes = Mathf.FloorToInt(t / 60f);
    //     float seconds = t % 60f;
    //     return $"Time: {minutes}:{seconds:00.0}";
    // }
    public TextMeshProUGUI stopwatchText;
    public bool stopwatchRunning = true;

    private float elapsedTime = 0f;

    void Update()
    {
        if (stopwatchRunning)
        {
            elapsedTime += Time.deltaTime;
            stopwatchText.text = FormatTime(elapsedTime);
        }
    }

    public void Stop()
    {
        stopwatchRunning = false;
    }

    public void ResetStopwatch()
    {
        elapsedTime = 0f;
        stopwatchRunning = true;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        float seconds = time % 60f;
        return $"Time: {minutes}:{seconds:00.00}";
    }
}
