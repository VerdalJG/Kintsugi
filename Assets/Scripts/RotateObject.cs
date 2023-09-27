using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float horizontalSpeed = -10.0F;
    public float verticalSpeed = 10.0F;
    public bool rotateEnabled;

    void Update()
    {
        if (rotateEnabled)
        {
            if (Input.GetMouseButton(0))
            {
                float h = horizontalSpeed * Input.GetAxis("Mouse X");
                float v = verticalSpeed * Input.GetAxis("Mouse Y");

                transform.Rotate(v, h, 0, Space.World);
            }
        }


        if (!rotateEnabled)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
    }

    public void DisableRotate()
    {
        rotateEnabled = false;
    }
}
