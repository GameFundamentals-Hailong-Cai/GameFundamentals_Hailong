using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private InputAction _MoveAction;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
       _playerInput = GetComponent<PlayerInput>();
        _MoveAction = _playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _MoveAction.ReadValue<Vector2>();
        
        _rigidbody.linearVelocity = move;
    }
}
