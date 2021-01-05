using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector3 move;
    public Rigidbody body;
    public float speed = 1000f;
    public float downSpeed = 4;
    public GameObject groundCheck;
    bool is_grounded = false;


    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerStay()
    {
        is_grounded = true;
    }

    private void OnTriggerExit()
    {
        is_grounded = false;
    }


    private void Move()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        if(!is_grounded)
        {
            move = (mH * transform.right + mV * transform.forward - downSpeed * transform.up).normalized;
        }
        else
        {
            move = (mH * transform.right + mV * transform.forward).normalized;
        }
        

        body.velocity = move * speed * Time.deltaTime;
    }
}
