// File: Assets/Scripts/ObjectRotator.cs
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    // Attach this script to the GameObject you want to rotate based on mouse movement.
    public class ObjectRotator : MonoBehaviour
    {
        [Header("Rotation Setup")]
        public float rotationSpeed = 5.0f; // Sensitivity for mouse movement

        void Update()
        {
            // Get the mouse movement deltas from our facade
            float mouseX = CapturedInput.GetAxis("Mouse X");
            float mouseY = CapturedInput.GetAxis("Mouse Y");

            // Apply rotation to this GameObject.
            // 'Mouse X' usually controls yaw (Y-axis rotation).
            // 'Mouse Y' usually controls pitch (X-axis rotation).
            // We typically invert the Y axis movement for intuitive mouse look.
            transform.Rotate(Vector3.up, mouseX * rotationSpeed);
            transform.Rotate(Vector3.right, -mouseY * rotationSpeed); // Invert Y for typical mouse look
        }
    }
}