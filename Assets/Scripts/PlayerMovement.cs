using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 movement;
    private Vector3 cameraMovement;
    private Vector2 mouseInput;
    
    private float xRotation = 0.0f;

    [SerializeField] LayerMask groundMask;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cameraT;
    [Space]
    [SerializeField] float sensivity;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float movementMultiplier = 1.0f;
    [SerializeField] float speed = 7.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        MovePlayer();
        //MoveCamera();
    }

    void MovePlayer()
    {
        Vector3 move = transform.right * movement.x + transform.forward * movement.z;

        if(controller.isGrounded)
        {
            velocity.y = -1f;
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        controller.Move(movementMultiplier * speed * Time.deltaTime * move);
        controller.Move(velocity * Time.deltaTime);
    }


    private void MoveCamera()
    {
        xRotation -= mouseInput.y * sensivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(0, mouseInput.x * sensivity, 0);
        cameraT.localRotation = Quaternion.Euler(xRotation, 0, 0);  
    }
}
