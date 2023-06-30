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

            disparos -= Time.deltaTime;
            if(disparos <= 0)
            {
                disparos = timeBetweenShots;
                var newbala = Instantiate(bala, firepoint.position, firepoint.rotation);
                newbala.transform.localScale = jefe.localScale;
            }

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
                    jefe.localScale = Vector3.one;

                    moveRight = false;

                    EndMovement();
                }
            }
            else
            {
              jefe.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                if(jefe.position.x < puntoIzq.position.x)
                {
                    jefe.localScale = new Vector3(-1f,1f,1f);

                    moveRight = true;

                    EndMovement();
                }
            }
            break;
        }
    }
    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;

        //anim.SetTrigger("Hit");
    }

    private void EndMovement()
    {
        currentStates = bossStates.shooting;
        disparos = timeBetweenShots;
        //anim.SetTrigger("StopMoving")
    }
    
}
