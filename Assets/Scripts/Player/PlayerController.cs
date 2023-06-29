using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField]
    private VariableJoystick variableJoystick;
    [SerializeField]
    private GameObject attackPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        movementInput = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);

        if (movementInput != Vector2.zero)
        {
            Move(movementInput);
            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Vertical", movementInput.y);
        }

        animator.SetFloat("Magnitude", movementInput.magnitude);
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        SetAttackPosition(movementInput);
    }

    void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private const float Threshold = 0.1f;
    private const float HorizontalOffset = 0.5f;
    private const float VerticalOffset = 0.5f;
    void SetAttackPosition(Vector2 movementInput)
    {
        float absX = Mathf.Abs(movementInput.x);
        float absY = Mathf.Abs(movementInput.y);

        if (absX > absY)
        {
            if (movementInput.x > Threshold)
            {
                attackPosition.transform.localPosition = new Vector3(HorizontalOffset, 0, 0);
            }
            else if (movementInput.x < -Threshold)
            {
                attackPosition.transform.localPosition = new Vector3(-HorizontalOffset, 0, 0);
            }
        }
        else
        {
            if (movementInput.y > Threshold)
            {
                attackPosition.transform.localPosition = new Vector3(0, VerticalOffset, 0);
            }
            else if (movementInput.y < -Threshold)
            {
                attackPosition.transform.localPosition = new Vector3(0, -VerticalOffset, 0);
            }
        }

    }

}
