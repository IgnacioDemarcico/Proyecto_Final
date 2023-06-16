using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    public bool moneda;
    private bool agarrada;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !agarrada)
        {
            if(moneda)
            {
                LevelManager.instance.monedasAgarradas++;
                agarrada = true;
                Destroy(gameObject);
            }
        }
    }
    
}
