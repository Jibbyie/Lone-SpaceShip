using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // Member Variables
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;  // cycle speed

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // If float period value is less than or equal to the smallest floating point value

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2; // value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculation to go from 0 to 1 for easier comprehension 
                                  
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset; // update position of the object to that of the starting position + offset
    }
}
