
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    // Attach this script to an empty GameObject.
    // Drag a visual object (like a small sphere or sprite) into the 'cursorObject' slot.
    // This script will move the 'cursorObject' to the mouse position in world space.
    public class MouseFollower : MonoBehaviour
    {
        [Header("Cursor Setup")]
        // Assign the GameObject that will visually represent the cursor here
        public GameObject cursorObject;
        // How far in front of the camera the cursor should appear (in world units)
        public float cursorDepth = 10.0f;

        private Camera mainCamera;

        void Awake()
        {
            // Find the main camera
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("MouseFollower: No Main Camera found in the scene!");
            }

            if (cursorObject == null)
            {
                Debug.LogError("MouseFollower: 'Cursor Object' is not assigned! Please assign a GameObject to represent the cursor.");
            }
        }

        void Update()
        {
            if (mainCamera == null || cursorObject == null)
            {
                return; // Cannot function without camera or cursor object
            }

            // Get the mouse position from our facade
            Vector3 mouseScreenPosition = CapturedInput.mousePosition;

            // Convert the screen position to a world position.
            // ScreenToWorldPoint requires a Z coordinate. We'll use cursorDepth
            // relative to the camera's position.
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
                new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane + cursorDepth)); // Add depth relative to near clip plane

            // Update the cursor object's position
            cursorObject.transform.position = worldPosition;

            // Optional: Keep the cursor object's rotation clean if it's following in 3D space
            // cursorObject.transform.rotation = Quaternion.identity;
        }
    }
}