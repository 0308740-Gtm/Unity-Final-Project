using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator anim;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();  
       anim = GetComponent<Animator>();

        if (trailRenderer != null) trailRenderer.emitting = false;
    }

    void OnDash(InputValue value)
    {
        if (canDash && !isDashing && moveInput != Vector2.zero)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    void OnMove(InputValue value)
    {
        if (isDashing) return;

        moveInput = value.Get<Vector2>();

        if (anim!= null)
        {
            anim.SetFloat("MovementX", moveInput.x);
            anim.SetFloat("MovementY", moveInput.y);
        }
    }

    void FixedUpdate()
    {
        if (isDashing) return;

        rb.velocity = moveInput * movespeed;
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.velocity = moveInput.normalized * dashingPower;

        if (trailRenderer != null) trailRenderer.emitting = true;

        yield return new WaitForSeconds(dashingTime);

        if (trailRenderer != null) trailRenderer.emitting = false;

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}



