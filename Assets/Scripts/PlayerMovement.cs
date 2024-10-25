using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 move;

    private float xAxis, zAxis = 0;
    private bool shiftPressed;

    [SerializeField] float movementMultiplier = 1.0f;
    [SerializeField] float MaxSpeed = 5;
    [SerializeField] float Acceleration = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);
        move.Set(xAxis, 9.81f * Time.deltaTime, zAxis);
    }

    void FixedUpdate()
    {
        move.x = Mathf.MoveTowards(move.x, move.x * MaxSpeed, Acceleration * Time.fixedDeltaTime);
        move.z = Mathf.MoveTowards(move.z, move.z * MaxSpeed, Acceleration * Time.fixedDeltaTime);
        rb.velocity = move * movementMultiplier;
        
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

}

public class SoundManager: MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}

public class GhostManager: MonoBehaviour
{
    public static GhostManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
