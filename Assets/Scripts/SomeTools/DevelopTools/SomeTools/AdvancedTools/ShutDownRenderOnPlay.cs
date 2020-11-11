using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDownRenderOnPlay : MonoBehaviour
{
    void Start()
    {
        var aux = GetComponent<Renderer>();
        if (aux)
        {
            GetComponent<Renderer>().enabled = false;
            enabled = false;
        }

        var aux2D = GetComponent<SpriteRenderer>();
        if (aux2D)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            enabled = false;
        }
    }
}
