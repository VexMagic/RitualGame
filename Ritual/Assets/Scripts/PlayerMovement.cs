using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private float moveSpeed;
    public int blood; //should move this to a seperated script "PlayerStats" or something
    private Vector2 movement;

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

    }

    private void Move()
    {
        rBody.MovePosition(rBody.position + movement * Time.fixedDeltaTime * moveSpeed);
    }
}
