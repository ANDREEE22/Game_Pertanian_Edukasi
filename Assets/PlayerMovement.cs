using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    // ----- TAMBAHAN KODE BARU DI SINI -----
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    // --------------------------------------

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ----- TAMBAHAN KODE BARU DI SINI -----
        // Mengambil komponen Animator dan SpriteRenderer dari Player
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // --------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        // ----- TAMBAHAN KODE BARU DI SINI -----
        // 1. Mengatur Animasi (Idle / Walk)
        // sqrMagnitude akan bernilai lebih dari 0 jika karakter bergerak (W, A, S, D ditekan)
        // KODE BARU (Lebih responsif untuk Animator)
        if (anim != null)
        {
            // Jika moveInput mendekati 0 (diam), kirim 0. Jika bergerak, kirim 1.
            float kecepatanAnimator = (moveInput.magnitude > 0.01f) ? 1f : 0f;
            anim.SetFloat("Speed", kecepatanAnimator);
        }

        // 2. Mengatur Arah Hadap Karakter (Flip)
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;  // Balik ke kiri jika menekan A
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false; // Hadap kanan normal jika menekan D
        }
        // --------------------------------------
    }

    public void move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}