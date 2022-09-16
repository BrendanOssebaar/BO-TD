using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector3 movement;
    // Vector3 mousePos;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        /*if (Input.GetKeyDown(KeyCode.A))
        {

        }*/
    }



}
