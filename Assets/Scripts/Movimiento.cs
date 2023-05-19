using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movete : MonoBehaviour
{
    public float velocidad = 5f;

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
    }
}
