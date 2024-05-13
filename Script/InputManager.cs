using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour


{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    public PlayerAttack attack;

    public bool Attack;
    public bool Fire { get; private set; }

    // Start is called before the first frame update

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Attack.performed += ctx => Fire = true;
        onFoot.Attack.canceled += ctx => Fire = false;
    }

    // Update is called once per frame

    void FixedUpdate()

    {
        Vector2 movement = onFoot.Movement.ReadValue<Vector2>();

        // Check if the Sprint action is being performed
        if (onFoot.Sprint.ReadValue<float>() > 0)
        {
            movement *= 3;
        }
        motor.ProcessMovement(movement);

    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()

    {
        onFoot.Jump.performed += ctx => motor.Jump();
        // onFoot.Attack.performed -= ctx => attack.AttackDistance();
        onFoot.Attack.Enable();
        onFoot.Enable();

    }

    private void OnDisable()

    {
        onFoot.Jump.performed -= ctx => motor.Jump();
        // onFoot.Attack.performed -= ctx => attack.AttackDistance();
        onFoot.Attack.Disable();
        onFoot.Disable();

    }
}