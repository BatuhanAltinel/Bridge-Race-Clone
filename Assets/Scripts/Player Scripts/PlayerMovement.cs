using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    Rigidbody _rigidbody;
    AnimatorManager animatorManager;
    Vector3 _moveVector;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            animatorManager.PlayWalkAnim();
        }

        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            animatorManager.PLayeIdleAnim();
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}