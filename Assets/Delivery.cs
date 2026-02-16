using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Delivery Item"))
        {
            Debug.Log("I entered a trigger with " + other.gameObject.tag);
            hasPackage = true;
        }

        if(other.CompareTag("Customer"))
        {
            Debug.Log("I entered a trigger with " + other.gameObject.tag);
            if(hasPackage)
            {
                Debug.Log("I delivered the package!");
                hasPackage = false;
            }
        }
    }
}
