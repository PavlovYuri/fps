using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxis
    {
        XY,
        X,
        Y
    }
    public RotationAxis axes = RotationAxis.XY;

    public float rotationHorizontalSpeed = 5.0f;
    public float rotationVerticalSpeed = 5.0f;

    public float minVert = -75.0f;
    public float maxVert = 75.0f;

    private float rotationX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.freezeRotation = true;
    }

    private void Update()
    {
        if ( axes == RotationAxis.XY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * rotationVerticalSpeed;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * rotationVerticalSpeed;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else if (axes == RotationAxis.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationHorizontalSpeed, 0);
        }
        else if (axes == RotationAxis.Y)
        {
            rotationX -= Input.GetAxis("Mouse Y") * rotationVerticalSpeed;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
