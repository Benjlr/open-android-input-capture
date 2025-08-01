using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPointerCapture.Demo
{
    public class IncreaseSizeOnClick : MonoBehaviour
    {
        bool goingUp = true;

        void Update()
        {
            if(CapturedInput.GetMouseButtonDown(0)){
                if(goingUp){
                    if((transform.localScale * 1.1f).sqrMagnitude > 16f){ 
                        goingUp = false;
                    } else {
                        transform.localScale *= 1.1f;
                    }
                }
                else{
                    // Using sqrMagnitude
                    if((transform.localScale * 0.9f).sqrMagnitude < 1){
                        goingUp = true;
                    } else {
                        transform.localScale *= 0.9f;
                    }
                }
            }
            if(CapturedInput.GetMouseButtonDown(1))
                transform.Rotate(Vector3.up * 10f);

            if(CapturedInput.GetMouseButtonDown(2))
                transform.Rotate(Vector3.right * 10f);

            Vector2 scrollDelta = CapturedInput.mouseScrollDelta;
            if(scrollDelta != Vector2.zero)
            {
                transform.Translate(Vector3.up * scrollDelta.y + Vector3.right * scrollDelta.x, Space.World);
            }
        }
    }
}
