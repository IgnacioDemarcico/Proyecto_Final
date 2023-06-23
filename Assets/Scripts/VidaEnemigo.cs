using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public static VidaEnemigo instance;
    [SerializeField]public float currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
     private void Muerte()
    {
        //animator.SetTrigger("Muerte");
    }
    public void TomarDanio(float DanioGolpe)
    {
        currentHealth -= DanioGolpe;
        if(currentHealth <= 0)
        {
           currentHealth = 0;
        }
        else
        {
        Movimiento.instance.KnockBack();//Probablemente se necesite en movimiento y no en playercontroller (Poner las variables y despues hacer el instance)
        }
    }
   
}
