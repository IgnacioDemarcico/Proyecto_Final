using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 50f;
    private bool enSuelo = true;
    private Rigidbody2D rb;
    public float KnockBackLength, knockBackForce;
    private float knockBackCounter;
    public static Movimiento instance;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(!MenuPausa.instance.enPausa)
        {
            if (knockBackCounter <= 0)
        {
            if (Input.GetKey("a"))
            {
                gameObject.GetComponent<Animator>().SetBool("movimiento", true);
                 spriteRenderer.flipX = true; // Voltea hacia la izquierda
            }
            if (Input.GetKey("d"))
            {
                gameObject.GetComponent<Animator>().SetBool("movimiento", true);
                 spriteRenderer.flipX = false; // Voltea hacia la derecha
            }
            if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                gameObject.GetComponent<Animator>().SetBool("movimiento", false);
            }
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            // Calcula la velocidad del movimiento
            Vector2 velocidadMovimiento = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

            // Aplica la velocidad al Rigidbody2D
            rb.velocity = velocidadMovimiento;

            if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
            {   
                gameObject.GetComponent<Animator>().SetBool("salta", true);
                StartCoroutine(Esperar());
                Saltar();
            }
        }
        else
           {
            knockBackCounter -= Time.deltaTime;
            if(!spriteRenderer.flipX)
            {
                rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
            }
           }
        }
    }

    private void Saltar()
    {
        // Aplica una fuerza vertical al Rigidbody2D para el salto
        gameObject.GetComponent<Animator>().SetBool("salta", true);
        rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        enSuelo = false;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.45f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el personaje ha colisionado con el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            gameObject.GetComponent<Animator>().SetBool("salta", false);
        }
    }
    public void KnockBack()
    {
        knockBackCounter = KnockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);
        gameObject.GetComponent<Animator>().SetBool("movimiento", false);
    }
}

