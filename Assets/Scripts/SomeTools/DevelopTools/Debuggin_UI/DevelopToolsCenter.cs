using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevelopTools.UI;
using Tools;
using System.Linq;

public class DevelopToolsCenter : MonoBehaviour
{
    public static DevelopToolsCenter instance; private void Awake() => instance = this;
    
    private void Start()
    {
        ToogleDebug(false);
        DevelopTools.UI.Debug_UI_Tools.instance.CreateToogle("Dummy Enemy State Machine Debug", false, ToogleDebug);
    }
    string ToogleDebug(bool active) 
    { 
        return active ? "debug activado" : "debug desactivado"; 
    }
   

}
