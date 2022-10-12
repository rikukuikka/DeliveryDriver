using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float _steerSpeed = 1f;
    [SerializeField]
    private float _moveSpeed = 20f;
    [SerializeField]
    private float _slowSpeed = 15f;
    [SerializeField]
    private float _boostSpeed = 30f;
    [SerializeField]
    private float _normalSpeed = 20f;

    void Start()
    {

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * _steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WorldObject")
        {
            Debug.Log("Hit " + other.collider.name);
            _moveSpeed = _slowSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Boost active");
            _moveSpeed = _boostSpeed;
        }
    }
}
