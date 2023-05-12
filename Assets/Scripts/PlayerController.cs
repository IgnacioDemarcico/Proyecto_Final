using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump;
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;
    public static PlayerController instance;

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
        if(knockBackCounter <= 0)
        {
            if(Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f * Time.deltaTime,0));
	        gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
            if(Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f * Time.deltaTime,0));
            gameObject.GetComponent<Animator>().SetBool("movimiento",true);
        }
	        if(!Input.GetKey("left") && !Input.GetKey("right"))
	    {
            gameObject.GetComponent<Animator>().SetBool("movimiento",false);
        }

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
    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        //theRB.velocity = new Vector(0f, knockBackForce); Esto no se puede porque theRB no existe
    }

}
