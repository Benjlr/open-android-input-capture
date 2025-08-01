using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    public class LookAtCamera : MonoBehaviour
    {
        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        }
    }
}
