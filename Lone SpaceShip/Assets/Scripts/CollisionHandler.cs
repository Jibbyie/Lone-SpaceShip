using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly! Watch out");
                break;
            case "Finish":
                Debug.Log("You reached the finish line! Wasn't.. very far.. but good job!");
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("You acquired Fuel");
                break;
            default:
                Debug.Log("Sorry, you gotta watch out next time!");
                ReloadLevel();
                break;
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
    }
}
