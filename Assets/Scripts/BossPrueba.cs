using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrueba : MonoBehaviour
{
    public enum bossStates{shooting, hurt, moving};
    public bossStates currentStates;
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
        currentStates = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentStates)
        {
            case bossStates.shooting:
            break;

            case bossStates.hurt:
            if(hurtCounter > 0)
            {
                hurtCounter -= Time.deltaTime;

                if(hurtCounter <= 0)
                {
                    currentStates = bossStates.moving;
                }
            }
            break;

            case bossStates.moving:
            if(moveRight)
            {
                jefe.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                if(jefe.position.x > puntoDer.position.x)
                {
                    moveRight = false;

                    currentStates = bossStates.shooting;

                    disparos = timeBetweenShots;
                }
            }
            else
            {
              jefe.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                if(jefe.position.x < puntoIzq.position.x)
                {
                    moveRight = true;

                    currentStates = bossStates.shooting;

                    disparos = timeBetweenShots;
                }
            }
            break;
        }
    }
    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;
    }
    
}
