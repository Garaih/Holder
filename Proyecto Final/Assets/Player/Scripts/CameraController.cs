using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement pScript;

    public float rotSpeed = 1;
    public float minYRot = -35;
    public float maxYRot = 60;
    public Transform target, player;
    public float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseY = Mathf.Clamp(mouseY, minYRot, maxYRot);

        if (!pScript.aiming)
        {
            transform.LookAt(target);
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        else
        {

        }
    }
}
