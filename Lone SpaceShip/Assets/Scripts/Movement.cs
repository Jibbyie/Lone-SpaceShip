using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Variables

    [SerializeField] float rocketThrustSpeed = 20f;
    [SerializeField] float rocketRotationSpeed = 20f;
    // Cached Reference
    Rigidbody rb;
    AudioSource rocketThrust;
 


    void Start()
    {
       rb = GetComponent<Rigidbody>();
       rocketThrust = GetComponent<AudioSource>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * rocketThrustSpeed * Time.deltaTime);
            if (!rocketThrust.isPlaying)
            {
                rocketThrust.Play();
            } 
            else
            {
                rocketThrust.Stop();
            }
        }
    }
    private  void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rocketRotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rocketRotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freeze physics engine rotation to allow manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreeze to allow physics engine to take over
    }

}
