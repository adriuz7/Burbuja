using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectorDispositivo : MonoBehaviour
{
    public GameObject controlesMovil; // Contenedor para los controles móviles
    public GameObject controlesPC; // Contenedor para los controles de PC

    void Start()
    {
        #if UNITY_IOS || UNITY_ANDROID
            HabilitarControlesMovil();
            InhabilitarControlesPC();
        #else
            HabilitarControlesPC();
            InhabilitarControlesMovil();
        #endif
    }

    void HabilitarControlesMovil()
    {
        if (controlesMovil != null)
        {
            controlesMovil.SetActive(true);
        }
    }

    void InhabilitarControlesMovil()
    {
        if (controlesMovil != null)
        {
            controlesMovil.SetActive(false);
        }
    }

    void HabilitarControlesPC()
    {
        if (controlesPC != null)
        {
            controlesPC.SetActive(true);
        }
    }

    void InhabilitarControlesPC()
    {
        if (controlesPC != null)
        {
            controlesPC.SetActive(false);
        }
    }
}
