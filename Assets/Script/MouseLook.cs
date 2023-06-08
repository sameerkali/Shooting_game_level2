/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    private float sensitivity = 4f;

    private void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    private float sensitivity = 4f;
    private float smoothness = 1f; // Adjust this value for desired smoothness

    private Vector2 smoothMouse = Vector2.zero;

    private void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
        smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothness);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothness);

        rotationY += smoothMouse.x;
        rotationX -= smoothMouse.y;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
