
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public float velocidad = 5;
    private const int ANIMATION_NORMAL = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;
    private const int ANIMATION_CORRERDISPARO = 3;
 
    private SpriteRenderer sr;
    private bool PuedeDisparar=true;
    public GameObject ball_righ_normal_ball;

    public GameObject ball_right_mediano_ball;
    
    public GameObject  ball_right_grande_ball;
    public GameObject ball_left_normal_ball;

    public GameObject ball_left_mediano_ball;
    
    public GameObject  ball_left_grande_ball;
    private bool puedoSaltar = true;
    public float upSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            CambiarAnimacion(ANIMATION_CORRER);
            sr.flipX = false;
            if(Input.GetKey(KeyCode.A))
            {
                 CambiarAnimacion(ANIMATION_CORRERDISPARO);
                if (!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .1f);
                    Instantiate(ball_righ_normal_ball, position, ball_righ_normal_ball.transform.rotation);
                }
            
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            CambiarAnimacion(ANIMATION_CORRER);
            sr.flipX = true;
            if(Input.GetKey(KeyCode.A))
            {
                 CambiarAnimacion(ANIMATION_CORRERDISPARO);
                if (!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .1f);
                    Instantiate(ball_righ_normal_ball, position, ball_righ_normal_ball.transform.rotation);
                }
            
            }
        }else{
              CambiarAnimacion(ANIMATION_NORMAL);//Metodo donde mi objeto se va a quedar quieto
            rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar==true)
        {
            rb.velocity = Vector2.up * upSpeed;
            CambiarAnimacion(ANIMATION_SALTAR);
            puedoSaltar = false;
           
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            
            if (!sr.flipX)
            {
                var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .1f);
                Instantiate(ball_righ_normal_ball, position, ball_righ_normal_ball.transform.rotation);
            }
            
            
        }
        if(Input.GetKeyDown(KeyCode.X) && Time.timeScale==3)
        {
            
            if (!sr.flipX)
            {
                var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .1f);
                Instantiate(ball_right_mediano_ball, position, ball_right_mediano_ball.transform.rotation);
            }
            
            
        }  
          
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 8)
            puedoSaltar = true;
        
    
 
    }
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("estado", animacion);
    }
    private void Coolldown_Disparo()
    {

    }
}
