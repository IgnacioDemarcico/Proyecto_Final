using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento: MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 50f;
    private bool enSuelo = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcula la velocidad del movimiento
        Vector2 velocidadMovimiento = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

        // Aplica la velocidad al Rigidbody2D
        rb.velocity = velocidadMovimiento;

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        // Aplica una fuerza vertical al Rigidbody2D para el salto
        rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        enSuelo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el personaje ha colisionado con el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}

