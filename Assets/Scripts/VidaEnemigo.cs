using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
           Destroy(gameObject);
           if(gameObject.CompareTag("Jefe"))
           {
            TerminarJuego();
           }
        }
        else
        {
            //Movimiento.instance.KnockBack();
        }
    }
    public void TerminarJuego()
    {
        SceneManager.LoadScene("FinDeJuego");
    }
   
}
