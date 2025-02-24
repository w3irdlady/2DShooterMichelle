using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth; //salud actual de Player
    public int maxHealth;   //salud máxima que Player va a tener.

    public static PlayerHealth instance; //esta instancia permitirá que podamos acceder ella desde otros scripts
 
    //permite acceder al script y las funciones de HealthBar.
    public HealthBar BarraSalud;

    public float immortalTime; //indica el tiempo de inmortalidad que tendrá el player tras recibir daño
    private float immortalCounter; // indicará si está en modo mortal o inmortal.

    //Referenciamos el sprite renderer para hacerlo transparente y modificar el color del player según la salud
    private SpriteRenderer sr;


    //Punto de respawn
    private Vector2 checkPoint;


    //Awake es llamado antes del primer fotograma en el que se activa el objeto al que está asignado este script 
    private void Awake()
    {
        instance = this; //hace que se instancie a sí misma para poder ser accedida desde otros scripts
    }


    // Start is called before the first frame update
    void Start()
    {
        //indicamos que l a posición del checkpoint de respawn es donde inicia
        checkPoint = transform.position;

        currentHealth = maxHealth; // la salud al arrancar el juego es la máxima disponible

        HealthBar.instance.SetMaxHealth(currentHealth); //corrección por que da null con la línea de abajo.

        // BarraSalud.SetMaxHealth(currentHealth); //hará que se vea la barra de salud de la UI llena al incicarse el juego.

        //llamamos al sprite renderer
        sr = GetComponent<SpriteRenderer>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if(immortalCounter > 0)
        {
            immortalCounter -= Time.deltaTime; //estamos reduciendo immortalConunter por el tiempo transcurrido.
            if (immortalCounter <= 0)
            {
               sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f); //hace que se vuelva sólido.
            }  
        }
    }

    // creamos nuestro propia función que será utilizado por otros scripts
    public void DealDamage() 
    {

        if (immortalCounter <= 0)
        {
            currentHealth--; //resta una unidad por cada daño que sufre Player

            HealthBar.instance.SetHealth(currentHealth);  // corrección por que da null object con el de abajo.
                                                          // BarraSalud.SetHealth(currentHealth); //actualiza la barra de salud de la UI al recibir daño

            //Si la salud actual llega a 0 o menos hace que Player desaparezca
            if (currentHealth <= 0)
            {

                // gameObject.SetActive(false); //hace que se desactive el player al morir
                Die();

            }
            else
            {
                immortalCounter = immortalTime;

                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.6f); //hace que se vuelva transparente
            }
        }
    }

    public void UpdatedCheckpoint(Vector2 pos)
    {
        checkPoint = pos;
    }


    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        currentHealth = maxHealth; 

        BarraSalud.SetHealth(currentHealth);

        transform.position = checkPoint;
    }
}
