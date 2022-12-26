using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _moveVector;
    AnimatorManager animatorManager;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    float randomX;
    float randomZ;
    float impulseForce = 15f;
    void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        _rb = GetComponent<Rigidbody>();
        _moveVector = Vector3.zero;
    }
    void Start()
    {
        GetDirection();
    }

   void Update()
   {
        BoundaryCheck();
   }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // _rb.MovePosition(_rb.position + _moveVector);
        // _rb.AddForce(_moveVector * Time.deltaTime * _moveSpeed);
        Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        animatorManager.PlayWalkAnim();
        
    }

    void GetDirection()
    {
        randomX = Random.Range(-1,2);
        randomZ = Random.Range(-1,2);

        _moveVector.x = randomX;
        _moveVector.z = randomZ;
        _moveVector.Normalize();
        // Debug.Log("move vector = " + _moveVector);
    }   

    void BoundaryCheck()
    {
        if(transform.position.x < -13)
            _rb.AddForce(new Vector3(1,0,0) * impulseForce *Time.deltaTime,ForceMode.Impulse);
        if(transform.position.x > 13)
        _rb.AddForce(new Vector3(-1,0,0) * impulseForce *Time.deltaTime,ForceMode.Impulse);
            // randomX = -1;
        if(transform.position.z < -13)
        _rb.AddForce(new Vector3(0,0,1) * impulseForce *Time.deltaTime,ForceMode.Impulse);
            // randomZ = 1;
        if(transform.position.z > 13)
        _rb.AddForce(new Vector3(0,0,-1) * impulseForce *Time.deltaTime,ForceMode.Impulse);
            // randomZ = -1;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            GetDirection();
            // Debug.Log("Crahs the wall");
        }
    }

}
