using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinVFXController : MonoBehaviour
{
    public float timeToStopDash = 0.3f;

    public ParticleSystem[] dashVFXs;
    public ParticleSystem.MainModule[] mainModules;

    public void StartDashVFX()
    {
        dashVFXs[0].Play();

        for (int i = 0; i < dashVFXs.Length; i++)
        {
            mainModules[i] = dashVFXs[i].main;
            mainModules[i].loop = true;
        }

        StartCoroutine(StopVFXAfterTime());
    }

    IEnumerator StopVFXAfterTime()
    {
        yield return new WaitForSeconds(timeToStopDash);

        for (int i = 0; i < dashVFXs.Length; i++)
        {
            mainModules[i] = dashVFXs[i].main;
            mainModules[i].loop = false;
        }
    }
}
