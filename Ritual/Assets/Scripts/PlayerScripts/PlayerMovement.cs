using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private float moveSpeed;
    private Vector2 movement;

    [Header("Event")]
    [SerializeField] private Vector2EventSO OnDirectionChange;

    public Vector2 Movement { get { return movement; } }

    void FixedUpdate()
    {
        //moves the player if a direction is inputed
        if (movement != Vector2.zero)
        {
            Move();
        }
    }

    private void OnMovement(InputValue value) //gets input from Unity Input System
    {
        movement = value.Get<Vector2>();
        OnDirectionChange.Invoke(movement);

    }

    private void Move()
    {
        rBody.MovePosition(rBody.position + movement * Time.fixedDeltaTime * moveSpeed);
    }
}
