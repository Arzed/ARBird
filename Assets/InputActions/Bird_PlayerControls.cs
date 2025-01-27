using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird_PlayerControls : MonoBehaviour
{
    public event Action<Vector2> OnMove = delegate { };
    public event Action<Vector2> OnRise = delegate { };

    private BirdInputActions playerInput;

    private InputAction moveAction;
    private InputAction riseAction;

    private void Awake()
    {
        playerInput = new BirdInputActions();
        moveAction = playerInput.BirdActionMaps.MoveForwardSide;
        riseAction = playerInput.BirdActionMaps.MoveUpDown;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        moveAction.performed += Move_Performed;
        moveAction.canceled += Move_Performed;

        riseAction.performed += RisePerformed;
        riseAction.canceled += RisePerformed;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        moveAction.performed -= Move_Performed;
        moveAction.canceled -= Move_Performed;

        riseAction.performed -= RisePerformed;
        riseAction.canceled -= RisePerformed;
    }

    private void Move_Performed(InputAction.CallbackContext ctx)
    {
        OnMove?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void RisePerformed(InputAction.CallbackContext ctx)
    {
        OnRise?.Invoke(ctx.ReadValue<Vector2>());
    }
}
