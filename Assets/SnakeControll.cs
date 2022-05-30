using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControll : MonoBehaviour
{
    private  Rigidbody _rigidBody;

    [SerializeField]
    private float _moveSpeed=80f;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveSnake();
    }

    void MoveSnake()
    {
         
        _rigidBody.velocity = transform.forward * Time.deltaTime * _moveSpeed;

        float angle = Input.GetAxis("Horizontal") * 3;

        transform.Rotate(0, angle, 0);
    }
    public void SpeedBoost()
    {
        _moveSpeed += 20f;
    }
}
