using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code originally used for possibility of player controlled locomotion
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] float horizontal = 0;
    [SerializeField] float vertical = 0;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (vertical != 0)
        {
            rb.velocity = transform.forward * speed * vertical * Time.deltaTime;
        }


    }
}
