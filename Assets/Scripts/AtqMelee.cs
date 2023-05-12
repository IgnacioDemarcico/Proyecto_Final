using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtqMelee : MonoBehaviour
{
   /* // Start is called before the first frame update
   [SerializeField] private Transform controladorMelee;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float DanioGolpe;
    //[SerializeField] private float cooldown; para el tiempo entre ataques
    //private Animator animator; SIRVE DESPUES CUANDO TENGAMOS LAS ANIMACIONES

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }
    private void Golpe()
    {
        //animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorMelee.position, radioGolpe);
        foreach(Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.Getcomponent<Enemigo>().TomarDanio(DanioGolpe);
            }
        }
    }
    private void DibujarGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorMelee.position,radioGolpe); 
    }*/
    
}
