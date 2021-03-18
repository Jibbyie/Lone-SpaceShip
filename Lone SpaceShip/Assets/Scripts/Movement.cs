using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Variables

    [SerializeField] float rocketThrustSpeed = 20f;
    // Cached Reference
    Rigidbody rb;


    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private  void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A - Rotating Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D - Rotating Right");
        }
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * rocketThrustSpeed * Time.deltaTime);
        }
    }
}
