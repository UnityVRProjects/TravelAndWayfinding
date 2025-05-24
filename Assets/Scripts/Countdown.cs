using UnityEngine;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public XRControllerMovement movementScript;
    public Stopwatch stopwatchManager;
    public float countdownTime = 3f;

    void Start()
    {
        movementScript.enabled = false;
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        float t = countdownTime;
        while (t > 0)
        {
            countdownText.text = Mathf.CeilToInt(t).ToString();
            yield return new WaitForSeconds(1f);
            t -= 1f;
        }

        countdownText.text = "GO!";
        movementScript.enabled = true;
        if (stopwatchManager != null)
        {
            // stopwatchManager.stopwatchRunning = true;
            stopwatchManager.Go();
        }

        yield return new WaitForSeconds(0.5f);
        countdownText.text = "";
    }
}
