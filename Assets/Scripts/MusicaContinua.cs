using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaContinua : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
{
    // Este objeto no se destruirá cuando cambies de escena.
    DontDestroyOnLoad(gameObject);
}

}
