using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Delivery Item") && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Customer"))
        {
            if(hasPackage)
            {
                Debug.Log("I delivered the package!");
                hasPackage = false;
            }
        }
    }
}
