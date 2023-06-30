using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrueba : MonoBehaviour
{
    public Transform jefe;
   // public Animator anim;

    [Header("Movimiento")]
    public float moveSpeed;
    public Transform puntoIzq, puntoDer;
    private bool moveRight;

    [Header("Disparos")]
    public GameObject bala;
    public Transform firepoint;
    public float timeBetweenShots;
    private float disparos;

    [Header("DañoRecibido")]
    public float hurtTime;
    private float hurtCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
