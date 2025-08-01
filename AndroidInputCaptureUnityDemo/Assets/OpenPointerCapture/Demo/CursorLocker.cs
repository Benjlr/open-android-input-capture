using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    public class CursorLocker : MonoBehaviour
    {
        public void SetCursorLocked(bool locked)
        {
            if (locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}