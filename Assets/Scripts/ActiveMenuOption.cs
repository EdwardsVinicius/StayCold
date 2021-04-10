using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenuOption : MonoBehaviour
{
    public GameObject objeto;

    public void ActivateOptionState()
    {
        objeto.SetActive(true);
    }

    public void DeactivateOptionState()
    {
        objeto.SetActive(false);
    }
}
