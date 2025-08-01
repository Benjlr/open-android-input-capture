using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    public class RotateCameraOnCapturedPointerMoved : MonoBehaviour
    {
        public float sensitivity { get; set; } = 1f;
        public bool invertY { get; set; } = false;
        private void Start()
        {
            PointerCaptureManager.OnCapturedPointerMoved += OnCapturedPointerMove;
        }
        private void OnDestroy()
        {
            PointerCaptureManager.OnCapturedPointerMoved -= OnCapturedPointerMove;
        }
        private void OnCapturedPointerMove(Vector2 delta)
        {
            Camera.main.transform.Rotate(delta.y * sensitivity * (invertY ? 1f : -1f), delta.x * sensitivity, 0, Space.Self);
        }
    }
}