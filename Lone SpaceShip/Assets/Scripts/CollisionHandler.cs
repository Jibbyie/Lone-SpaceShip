using UnityEngine;

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
                break;
            case "Fuel":
                Debug.Log("You acquired Fuel");
                break;
            default:
                Debug.Log("Sorry, you gotta watch out next time!");
                break;

        }
    }
}
