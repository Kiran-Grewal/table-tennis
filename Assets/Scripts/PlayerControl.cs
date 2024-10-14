using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private KeyCode _moveUp = KeyCode.UpArrow;
    private KeyCode _moveDown = KeyCode.DownArrow;
    [SerializeField]
    private bool _isAI;
    private GameObject _ball;
    private float _speed = 10;
    private float _boundary = 2.25f;
    private Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAI) 
        {
            ComputerMovement();
        }
        else
        {
            PlayerMovement();
        }
        Vector3 pos = transform.position;
        if (pos.y > _boundary)
        {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary)
        {
            pos.y = -_boundary;
        }
        transform.position = pos;

    }

    public void PlayerMovement()
    {
        Vector2 vel = _rb2d.velocity;
        if (Input.GetKey(_moveUp))
        {
            vel.y = _speed;
        }
        else if (Input.GetKey(_moveDown))
        {
            vel.y = -_speed;
        }
        else
        {
            vel.y = 0;
        }
        _rb2d.velocity = vel;
    }

    public void ComputerMovement()
    {
        Vector2 vel = _rb2d.velocity;
        if(_ball.transform.position.y > transform.position.y + 0.6f)
        {
            vel.y = _speed;
        }
        else if(_ball.transform.position.y < transform.position.y - 0.6f)
        {
            vel.y = -_speed;
        }
        else
        {
            vel.y = 0;
        }
        _rb2d.velocity = vel;
    }

}
