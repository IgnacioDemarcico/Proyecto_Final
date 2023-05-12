using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump;

    public float velocidad;
    private bool puedeMoverse; //va a servir para cuando un enemigo lo golpee
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("left"))
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
    }
        //ProcesarMovimiento();
        Salto();
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

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
    }
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