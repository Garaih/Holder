using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;

    [Header("Movement variables")]
    public float speed = 10;
    public float currentSpeed;
    public float gravityForce = -9.81f;
    public float jumpHeight = 3f;
    public Vector3 velocity;

    [Header("Check variables")]
    public Transform groundCheck;
    public float checkDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Rotation variables")]
    public Transform camTarget;
    public CameraController camScript;

    float xInput, zInput;
    Vector3 moveDirection;

    void Start()
    {

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        moveDirection = camTarget.right * xInput + camTarget.forward * zInput;

        if (xInput == 0 && zInput == 0)
        {
            currentSpeed = 0;
        }

        else
        {
            currentSpeed = speed;
        }

        cc.Move(moveDirection * currentSpeed * Time.deltaTime);

        if(xInput != 0 || zInput != 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, 360 * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            //transform.rotation = Quaternion.Euler(transform.rotation.x, newDirection.y, transform.rotation.z);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityForce);
        }

        velocity.y += gravityForce * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }
}
