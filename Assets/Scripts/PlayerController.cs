using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump;
<<<<<<< HEAD
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;
    public static PlayerController instance;

=======

    public float velocidad;
>>>>>>> 35af8668ec7aa16e05bf530e3423168c8d74fad8
    private bool puedeMoverse; //va a servir para cuando un enemigo lo golpee
    
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(knockBackCounter <= 0)
        {
            if(Input.GetKey("left"))
=======
       if(Input.GetKey("left"))
>>>>>>> 35af8668ec7aa16e05bf530e3423168c8d74fad8
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f * Time.deltaTime,0));
	        gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
            if(Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(250f * Time.deltaTime,0));
            gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
<<<<<<< HEAD
	        if(!Input.GetKey("left") && !Input.GetKey("right"))
	    {
            gameObject.GetComponent<Animator>().SetBool("movimiento",false);
        }

=======
	if(!Input.GetKey("left") && !Input.GetKey("right"))
	{
        gameObject.GetComponent<Animator>().SetBool("movimiento",false);
    }
        //ProcesarMovimiento();
>>>>>>> 35af8668ec7aa16e05bf530e3423168c8d74fad8
        Salto();

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

    }

    void Salto()
    {
        if(Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50f));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "suelo")
        {
            canJump = true;
        }
    }
<<<<<<< HEAD
    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        //theRB.velocity = new Vector(0f, knockBackForce); Esto no se puede porque theRB no existe
    }

=======

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
    }
>>>>>>> 35af8668ec7aa16e05bf530e3423168c8d74fad8
}
 /*if(Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f * Time.deltaTime,0));
	        gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
        if(Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(250f * Time.deltaTime,0));
            gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
	if(!Input.GetKey("left") && !Input.GetKey("right"))
	{
        gameObject.GetComponent<Animator>().SetBool("movimiento",false);
    }*/