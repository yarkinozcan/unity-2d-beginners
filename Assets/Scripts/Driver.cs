using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] float turboSpeed = 10f;
    [SerializeField] TMP_Text boostDisplay;

    void Start()
    {
        boostDisplay.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            currentSpeed = turboSpeed;
            boostDisplay.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnvironmentCollider"))
        {
            currentSpeed = regularSpeed;
            boostDisplay.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        if(Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if(Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        if(Keyboard.current.dKey.isPressed)
        {   
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
