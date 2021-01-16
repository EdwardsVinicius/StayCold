using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public void ActivatePlayerHitVFX()
    {
        transform.parent.GetComponent<Player>().ShowHitVFX();
    }
}
