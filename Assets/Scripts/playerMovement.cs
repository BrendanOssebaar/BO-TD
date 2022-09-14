using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool canDash = true;
    private bool isDashing;

    [SerializeField] private float dashingPower = 10f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    
    Vector2 movement;
    Vector2 mousePos;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private TrailRenderer tr;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }


    }

    void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (isDashing)
        {
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = movement * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    

}
