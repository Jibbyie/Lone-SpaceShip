using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Inspector Variables
    [SerializeField] float invokeDelay = 1f;

    //Cached References

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly! Watch out");
                break;
            case "Finish":
                StartSuccessSequence();
                Debug.Log("You reached the finish line! Wasn't.. very far.. but good job!");
                break;
            case "Fuel":
                Debug.Log("You acquired Fuel");
                break;
            default:
                StartCrashSequence();
                Debug.Log("Sorry, you gotta watch out next time!");
                break;
        }
    }
        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        void LoadNextLevel()
        {

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    
    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", invokeDelay);
    }

    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", invokeDelay);
    }
}
