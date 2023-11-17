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
           if(gameObject.CompareTag("Jefe"))
           {
            StartCoroutine(muerteJefe());
           }
           else if(gameObject.CompareTag("Jefe2"))
           {
            SceneManager.LoadScene("FinDeJuego");
           }
        }
        if(currentHealth <= 0 && gameObject.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
        }
    }
    public void TerminarJuego()
    {   
        SceneManager.LoadScene("LevelSelect");
    }
    IEnumerator muerteJefe()
    {   
        gameObject.GetComponent<Animator>().SetBool("death", true);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Animator>().SetBool("death", false);
        Destroy(gameObject);
        TerminarJuego();
    }
}
