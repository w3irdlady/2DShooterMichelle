using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;     // Variable que indica la velocidad que tienen un objeto (pública)
    private Rigidbody2D rb;     // Variable que llama al rigidbody (privada)
    private float direction;    // Variable para indicar qué dirección se está utilizando.

    public float jumpForce;     //Variable de la fuerza con la que salta.


    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool isGrounded;

    private SpriteRenderer sr;

    private Animator anim;

    private bool isFacengRight=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  velocidad del personaje  */
        if (!PauseMenu.instance.isPaused)
        {
            direction = Input.GetAxisRaw("Horizontal");                         //variable dirección toma los controles del input manager Horizontal
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);    //la velocidad del rigidbody equivale un nuevo vector dos

            /* salto del personaje */


            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            /* dirección del personaje */

            if (rb.velocity.x < 0)
            {
                //sr.flipX = true;      // Se quita por que no facilita el disparo

                //Hace que todo el gameobject se gire, incluyendo los elementos child
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

                //Player está mirando a la izquierda
                isFacengRight = false;
            }

            else if (rb.velocity.x > 0)
            {
                //sr.flipX = false;       // Se quita por que no facilita el disparo

                //Hace que todo el gameobject se gire, incluyendo los elementos child
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

                //Player está mirando a la derecha
                isFacengRight = true;
            }
        }

       

        /* animaciones personaje */

        anim.SetFloat("moveSpeed", Mathf.Abs (rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    public bool IsFacingRight()
    {
        return isFacengRight;
    }


}
