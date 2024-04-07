using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _dirHorizontal;
    private float _dirVertical;
    private float newPositionX;
    private float newPositionY;

    public void SetDirection(float dirHorizontal, float dirVertical)
    {
        _dirHorizontal = dirHorizontal;
        _dirVertical = dirVertical;
    }
    
    public void SaySomething()
    {
        Debug.Log("Something");
    }

    private void Update()
    {
        newPositionX = transform.position.x;
        newPositionY = transform.position.y;

        if (_dirHorizontal != 0)
        {
            var deltaX = _dirHorizontal * _speed * Time.deltaTime;
            newPositionX = transform.position.x + deltaX;
        }
        if (_dirVertical != 0)
        {
            var deltaY = _dirVertical * _speed * Time.deltaTime;
            newPositionY = transform.position.y + deltaY;
        }

        transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
    }
}
