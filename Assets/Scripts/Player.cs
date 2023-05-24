using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Velocità di movimento del personaggio
    Vector3 movement;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (movement != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(-movement, Vector3.up);
            //rb.MoveRotation(Quaternion.Lerp(rb.rotation, toRotation, 0.5f));
        }
    }

    private void Update()
    {
        // Calcola il vettore di movimento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0f, moveVertical);
    }
}
