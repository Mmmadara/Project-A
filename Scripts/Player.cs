using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Player : MonoBehaviour, IMovable, IDamageable, IRotatable
{
    
    public enum ControlType{PC, Android};
    public ControlType controlType /*= ControlType.Android*/;
    public Joystick joystick;
    
    public int Speed { get; set; } = 5;
    
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Move();
        Flip();
        
    }

    public void FixedUpdate()
    {
        FixedMove();
    }

    public void Move()
    {
        if (controlType == ControlType.PC)
        { 
            _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if (controlType == ControlType.Android)
        {
            _moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        _moveVelocity = _moveInput.normalized * Speed;
    }

    public void FixedMove()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }
    
    public void ApplyDamage(int damageValue)
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        throw new NotImplementedException();
    }

    public void Flip()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (this.transform.position.x < worldPos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
