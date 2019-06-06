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
    public GameObject laCamera;
    private ViewScript viewScript;
    public GameObject timer;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        viewScript = laCamera.GetComponent<ViewScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
      

        brique br = collision.gameObject.GetComponent<brique>();
        if(br)
        {
            br.TakeDamage(10);
        }
    }

    public void LaunchBall()
    {
        _isMoving = true;
        _rb.AddForce(transform.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "DeadZone")
        { 
            if(WordSettings.Instance.nbBalle == 1)
            {
                Respawn();

                if (WordSettings.Instance.hpPlayer <= 0)
                {
                    WordSettings.Instance.GameOver();
                }
            }
            else
            {
                Destroy(gameObject);
                WordSettings.Instance.nbBalle--;
             
            }
            
        }
    }


    private void Respawn()
    {
        WordSettings.Instance.hpPlayer--;
        timer.GetComponent<TimerScript>().ResetTimer();
        timer.GetComponent<TimerScript>().SetTimer(3f);
        timer.GetComponent<TimerScript>().StartTimer();
        transform.position = _startPosition;
        _rb.velocity = Vector3.zero;
        viewScript.TimeBeforeLaunch = 5f;
        _isMoving = false;
        
    }
}
