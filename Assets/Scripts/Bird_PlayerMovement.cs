using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Bird_PlayerMovement : MonoBehaviour
{
    public float speed = .5f;
    public float rotationSpeed = 40.0f;
    public float riseSpeed = .015f;
    public float distanceOffset = .25f;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 riseInput = Vector2.zero;
    private Bird_PlayerControls playerControls;

    private void Awake()
    {
        playerControls = GetComponent<Bird_PlayerControls>();
    }

    private void OnEnable()
    {
        playerControls.OnMove += HandleMove;
        playerControls.OnRise += HandleRise;
    }

    private void OnDisable()
    {
        playerControls.OnMove -= HandleMove;
        playerControls.OnRise -= HandleRise;
    }

    private void HandleMove(Vector2 input)
    {
        moveInput = input;
    }

    private void HandleRise(Vector2 input)
    {
        riseInput = input;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanceOffset);
    }

    private void Update()
    {
        float rotationAmount = moveInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);

        Vector3 moveVector = transform.forward * moveInput.y * speed * Time.deltaTime;
        moveVector += new Vector3(0, riseInput.y * riseSpeed, 0);
        transform.position += moveVector;
    }
}

