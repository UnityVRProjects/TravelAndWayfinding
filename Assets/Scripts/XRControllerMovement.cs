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
    public float moveSpeed = 80f;
    public XROrigin xrOrigin;
    public Transform controllerTransform;        // Right hand/controller transform


    public Camera mainCam;
    public Camera thirdviewCam;
    public Transform LcontrollerTransform;
    public InputActionProperty thirdPOV;

    private bool lastThirdPOVPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        flyTrigger.action.Enable();

        thirdPOV.action.Enable();
        mainCam.gameObject.SetActive(true);
        thirdviewCam.gameObject.SetActive(false);
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

        bool isThirdPOVPressed = thirdPOV.action.IsPressed();
        if (isThirdPOVPressed && !lastThirdPOVPressed)
        {
            // Toggle cameras
            bool useThirdView = !thirdviewCam.gameObject.activeSelf;
            thirdviewCam.gameObject.SetActive(useThirdView);
            mainCam.gameObject.SetActive(!useThirdView);
            if (useThirdView) {
                xrOrigin.Camera = thirdviewCam;
            } else {
                xrOrigin.Camera = mainCam;
            }
        }
        lastThirdPOVPressed = isThirdPOVPressed;
    }
}
