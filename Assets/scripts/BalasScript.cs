using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasScript : MonoBehaviour
{
    public float velocityX = 10f;
    private Rigidbody2D rb;
    private MegamanScript megamanScript;

     public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        megamanScript = FindObjectOfType<MegamanScript>();
        
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * velocityX;
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombi")
        {
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
           // megamanScript.IncrementerPuntajeEn10();
        }
    }
}
