using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera cam;

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

        transform.localEulerAngles = new Vector3(rotationPitch, rotationYaw, transform.localEulerAngles.z);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}