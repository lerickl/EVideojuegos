using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = true;
    }
}
