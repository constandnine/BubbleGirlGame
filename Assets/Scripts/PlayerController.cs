using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("input")]

    private InputActions inputActions;


    [Header("Movement")]

    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 movementDirection;


    [Header("Rotation")]

    [SerializeField] private GameObject verticalRotationPoint;

    [SerializeField] private float horizontalRotationSpeed;
    [SerializeField] private float verticalRotationSpeed;
    private Vector2 rotationInput;


    private void Awake()
    {
        inputActions = new InputActions();
    }


    private void OnEnable()
    {
        // enebles the inputactions.
        inputActions.Enable();
    }


    private void OnDisable()
    {
        // Disables the InputActions.
        inputActions.Disable();
    }


    public void MovementInput(InputAction.CallbackContext context)
    {
        // Gets the value of the Left joystick
        movementDirection = context.ReadValue<Vector2>();
    }


    public void RotationInput(InputAction.CallbackContext context)
    {
        // Gets the value of the right joystick
        rotationInput = context.ReadValue<Vector2>();
    }


    private void Update()
    {
        Movement();
        Rotation();
    }


    public void Movement()
    {
        // sets the vlalue of the right joycon to a vector 2.
        Vector2 movementInput = inputActions.Player.Movement.ReadValue<Vector2>();


        // checks if the 
        if (movementInput != Vector2.zero)
        {
            // Calculate the degreeof the angle of the movement direction from the joycon input.
            float targetAngle = Mathf.Atan2(-movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;

            // Converts the angle to radians
            float angleRadian = targetAngle * Mathf.Deg2Rad;

            // Calculates the movement direction as a vector based on the angle.
            Vector3 moveDirection = new Vector3(Mathf.Sin(angleRadian), 0, Mathf.Cos(angleRadian));


            // moves the player to the new direction
            transform.Translate(moveDirection * Time.deltaTime * movementSpeed, Space.World);
        }
    }


    public void Rotation()
    {
        if (rotationInput != Vector2.zero)
        {
            // Rotates horizontally based on the X-axis of the right joystick
            float horizontalRotation = rotationInput.x * horizontalRotationSpeed * Time.deltaTime;

            // Rotates vertically based on the Y-axis of the right joystick
            float verticalRotation = rotationInput.y * verticalRotationSpeed * Time.deltaTime;


            // Applys horizontal rotation
            transform.Rotate(0, horizontalRotation, 0);

            // Applys vertical rotation
            verticalRotationPoint.transform.Rotate(-verticalRotation, 0, 0);
        }
    }
}
