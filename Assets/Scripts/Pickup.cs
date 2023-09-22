using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    public bool moneda, curacion;
    private bool agarrada;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !agarrada)
        {
            if(moneda)
            {
                LevelManager.instance.monedasAgarradas++;
                UIController.instance.UpdateContadorMonedas();
                agarrada = true;
                Destroy(gameObject);
            }
            if(curacion)
            {
                if(PlayerVida.instance.currentHealth != PlayerVida.instance.maxHealth)
                {
                    PlayerVida.instance.HealPLayer();
                    agarrada= true;
                    Destroy(gameObject);
                }
            }
        }
    }
    
}
