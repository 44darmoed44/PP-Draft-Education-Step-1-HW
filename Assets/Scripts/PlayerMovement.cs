﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    
    public void SaySomething()
    {
        Debug.Log("Something");
    }

    private void Update()
    {
        if (_direction.magnitude > 0)
        {
            var delta = _direction * _speed * Time.deltaTime;
            transform.position = transform.position + new Vector3(delta.x, delta.y, transform.position.z);
        }
    }
}