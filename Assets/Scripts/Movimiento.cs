/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movete : MonoBehaviour
{
    public float velocidad = 5f;
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;
    public static PlayerController instance;

    private Rigidbody2D rb;

    /*private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
        if(knockBackCounter <= 0)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");

            // Calcula la velocidad del movimiento
            Vector2 velocidadMovimiento = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

            // Aplica la velocidad al Rigidbody2D
            rb.velocity = velocidadMovimiento;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
    }
    public void Knockback()
    {
        knockBackCounter = knockBackLength;

    }
}*/
