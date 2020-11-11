using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndElementSpawn : MonoBehaviour
{
    public void TRIGGER_EndElementSpawn()
    {
        FaseManager.instance.TRIGGER_EndElement();
    }
}
