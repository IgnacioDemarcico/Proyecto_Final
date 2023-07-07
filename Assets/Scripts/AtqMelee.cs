using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtqMelee : MonoBehaviour
{
    [SerializeField] private Transform controladorMelee;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danioGolpe;

    private bool isAttacking = false;

    private void Golpe()
    {
        if (isAttacking)
            return;

        isAttacking = true;

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorMelee.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo") || colisionador.CompareTag("Jefe"))
            {
                colisionador.transform.GetComponent<VidaEnemigo>().TomarDanio(danioGolpe);
            }
        }

        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        // Esperar un pequeño tiempo antes de permitir otro ataque
        yield return new WaitForSeconds(0.2f);

        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorMelee.position, radioGolpe);
    }

    private void Update()
    {
        if (Input.GetKey("e"))
        {
            Golpe();
        }
    }
}
