using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public static PlayerVida instance;
    [SerializeField]public int currentHealth, maxHealth;
    public float ivencibleLength;
    private float ivencibleCounter;
    private SpriteRenderer sprai;
    [SerializeField] private BarraDeVida barraDeVida;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        sprai = GetComponent<SpriteRenderer>();
        barraDeVida.InicializarBarraDeVida(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(ivencibleCounter > 0)
        {
            ivencibleCounter -= Time.deltaTime;
            if(ivencibleCounter <= 0)
            {
                sprai.color = new Color(sprai.color.r,sprai.color.g,sprai.color.b,1f);
            }
        }
    }
    public void AplicarGolpe()
    {
        if (ivencibleCounter <= 0)
        {
            currentHealth--;
            barraDeVida.CambiarVidaActual(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //StartCoroutine(muerte());
                LevelManager.instance.RespawnPlayer();

            }
            else
            {
                ivencibleCounter = ivencibleLength;
                sprai.color = new Color(sprai.color.r,sprai.color.g,sprai.color.b,.5f);
                Movimiento.instance.KnockBack();//Probablemente se necesite en movimiento y no en playercontroller (Poner las variables y despues hacer el instance)
            }
        }
        
    }
    IEnumerator muerte()
    {   
        gameObject.GetComponent<Animator>().SetBool("Muere", true);
        yield return new WaitForSeconds(0.45f);
        gameObject.GetComponent<Animator>().SetBool("Muere", false);
        LevelManager.instance.RespawnPlayer();

    }

     
    public void HealPLayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        barraDeVida.CambiarVidaActual(currentHealth);
    }
}
