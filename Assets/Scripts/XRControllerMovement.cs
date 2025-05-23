using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class XRControllerMovement : MonoBehaviour
{
    public InputActionProperty triggerInput;     // Trigger value (float)
    public InputActionProperty directionInput;   // Controller's pointing direction (pose)
    public InputActionProperty flyTrigger;
    public float moveSpeed = 50f;
    public XROrigin xrOrigin;
    public Transform controllerTransform;        // Right hand/controller transform

    // Start is called before the first frame update
    void Start()
    {
        flyTrigger.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float input = flyTrigger.action.ReadValue<float>();

        if (input > 0.1f)
        {
            Vector3 direction = controllerTransform.forward;

            transform.position += direction * input * moveSpeed * Time.deltaTime;
        }
    }
}
