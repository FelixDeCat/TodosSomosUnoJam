using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lnrender : MonoBehaviour
{
    public Transform l1;
    public Transform l2;

    public LineRenderer line;

    private void Update()
    {
        line.SetPosition(0, l1.position);
        line.SetPosition(1, l2.position);
    }
}
