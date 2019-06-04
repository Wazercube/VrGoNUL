using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    private bool oui;
    private Rigidbody _rb;
    public float _speed;
    private bool _isMoving = false;
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MoveRacket>() && !_isMoving)
        {
            _isMoving = true;
            transform.rotation = collision.transform.rotation;
            _rb.AddForce(transform.up * _speed);
        }

        brique br = collision.gameObject.GetComponent<brique>();
        if(br)
        {
            br.TakeDamage(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "DeadZone")
        {
            WordSettings.Instance.hpPlayer--;
            
            transform.position = _startPosition;
            _rb.velocity = Vector3.zero;
            _isMoving = false;
        }
    }
}
