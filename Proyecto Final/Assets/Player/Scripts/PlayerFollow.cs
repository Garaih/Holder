using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform PlayerTransform;
    public GameObject markerGO;

    private Vector3 _cameraOffset;
    private Quaternion camRotation = Quaternion.identity;

    public float rotX;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        _cameraOffset = transform.position - PlayerTransform.position;
        Cursor.lockState = CursorLockMode.Locked;

        markerGO.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
    }
	
	// LateUpdate is called after Update methods
	void LateUpdate () {

        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        
        if (!PlayerTransform.GetComponent<CharacterController>().isGrounded)
        {
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        }

        else
        {
            transform.position = newPos;
        }

        if (LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
            camRotation.eulerAngles = new Vector3(rotX, transform.rotation.eulerAngles.y, 0);
            transform.rotation = camRotation;
        }
	}
}
