using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;

    //Referencia al script player
    private Player playerController;
    //referencia al gameobject player
    private GameObject playerobj;


    private void Awake()
    {
        Destroy(gameObject, 2f);
    }

    void Start()
    {
        playerobj = GameObject.FindGameObjectWithTag("Player");
        playerController = playerobj.GetComponent<Player>();


        rb = GetComponent<Rigidbody2D>();

        //rb.velocity = transform.right * bulletSpeed;

        if (playerController.IsFacingRight()) 
        {
            rb.velocity = transform.right * bulletSpeed;
        }
        else
        {
            rb.velocity = -transform.right * bulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //para que destruya al enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    // para que el proyectil se destruya al colisionar
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy (gameObject);
    }

}
