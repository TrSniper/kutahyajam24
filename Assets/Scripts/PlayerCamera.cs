﻿using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform player;

    public float sensitivity = 1.0f;
    public float maxY = 60;
    public float minY = -60;
    private float rotationYaw = 0;
    private float rotationPitch = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotationYaw += Input.GetAxis("Mouse X") * sensitivity;
        rotationPitch -= Input.GetAxis("Mouse Y") * sensitivity;

        rotationPitch = Mathf.Clamp(rotationPitch, minY, maxY);

        cam.localEulerAngles = new Vector3(rotationPitch, 0, transform.localEulerAngles.z);
        player.localEulerAngles = new Vector3(0, rotationYaw, 0);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}