using FSM;
using PlayerSettings;
using PlayerSettings.PlayerConfigs;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private float _jumpForce ;
    
    private CharacterController _controller;
    private InputHandler _inputHandler;
    private StateMachine _stateMachine;
    private PlayerView _view;
    
    private float _gravity = 9.81f;
    
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputHandler = GetComponent<InputHandler>();
        _view = GetComponent<PlayerView>();

        _stateMachine = new StateMachine(_config,this, _view);
    }

    public void Move(float speed)
    {
        var input = _inputHandler.GetMovementInput();
        var move = transform.right * input.x + transform.forward * input.z;
        
        _controller.Move(move * (speed * Time.deltaTime));
    }
    
    public void Jump()
    {
        if (IsGrounded())
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * 2f * _gravity);
        }
    }

    private void Update()
    {
        ApplyGravity();
        CheckGround();
        
        _stateMachine.Update();
    }
    
    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity.y < 0)
        {
            _velocity.y = -2f; 
        }
        _velocity.y -= _gravity * Time.deltaTime; 
        _controller.Move(_velocity * Time.deltaTime);
    }
    
    private void CheckGround()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.1f; 
        _isGrounded = Physics.Raycast(rayStart, Vector3.down, 0.01f);
    }

    public bool HasMovementInput()
    {
        return _inputHandler.GetMovementInput().sqrMagnitude > 0.01f;
    }
    
    public bool IsJumpPressed()
    {
        return _inputHandler.IsJumpPressed();
    }
    
    public bool IsGrounded()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.1f;
        return Physics.Raycast(rayStart, Vector3.down, 1.2f);
    }
}
