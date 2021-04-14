using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    // Variables

    [SerializeField] float rocketThrustSpeed = 20f;
    [SerializeField] float rocketRotationSpeed = 20f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem rocketJetParticles;


    // Cached Reference
    Rigidbody rb;
    AudioSource audioSource;
    Collider rC;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
       rC = GetComponent<Collider>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        LevelSkipDebugKey();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void LevelSkipDebugKey()
    {
        SkipCurrentLevel();
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * rocketThrustSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!rocketJetParticles.isPlaying)
        {
            rocketJetParticles.Play();
        }
    }

    void StopThrusting()
    {
        rocketJetParticles.Stop();
        audioSource.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rocketRotationSpeed);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rocketRotationSpeed);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    void StopRotating()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    void SkipCurrentLevel()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freeze physics engine rotation to allow manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreeze to allow physics engine to take over
    }

}
