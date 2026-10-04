using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float JumpSpeed = 10;
    public bool isGrounded = false;
    public Rigidbody2D rb;
    // These variables are to hold the Action references
    InputAction moveAction;
    InputAction JumpAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Method to find the Rigidbody2D component attached to the GameObject
        // Find the references to the "Move" and "Jump" actions
        moveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        // Read the "Move" action value, which is a 2D vector
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveValue.x * moveSpeed;
       if (JumpAction.IsPressed())
        {
            Debug.Log("IsPressed");
        }
        if (JumpAction.WasPerformedThisFrame() && isGrounded)
        {
            rb.linearVelocityY = JumpSpeed;
            //isGrounded = false;
            Debug.Log("WasPressedThisFrame");
        }
        // your movement code here
       // transform.Translate(new Vector3(moveValue.x, moveValue.y, 0) * 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
