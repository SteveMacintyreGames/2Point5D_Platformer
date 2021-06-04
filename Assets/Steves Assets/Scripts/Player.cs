using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player is null");
            }
            return _instance;
        }
    }

    private CharacterController _controller;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15f;
    private float _yVelocity; 
    private bool _canDoubleJump;

    [SerializeField] private int _coins;


    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _coins = 0;
    }

    void Update()
    {        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput,0f,0f);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        UIManager.Instance.UpdateCoinText(_coins);

    }

    public void AddCoins()
    {
        _coins++;
    }
}
