using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //define the actions
    InputAction moveAction;
    InputAction aimAction;

    public PlayerSO player1Data;

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialise the actions
        moveAction = InputSystem.actions.FindAction("Move");
        aimAction = InputSystem.actions.FindAction("Aim");

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (aimAction.WasPressedThisFrame())
        {
            Debug.Log("Aim Button Pressed");
            ChangeFieldOfView();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement here
        Vector2 input = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = input * player1Data.speed;
    }

    public void ChangeFieldOfView()
    {
        if (player1Data.fov == 120 && player1Data.viewDistance == 15)
        {
            player1Data.fov = 60;
            player1Data.viewDistance = 30;
        }
        else 
        {
            player1Data.fov = 120;
            player1Data.viewDistance = 15;
        }
    }
}
