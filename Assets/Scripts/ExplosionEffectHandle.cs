using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectHandle : MonoBehaviour
{
    public float particleLifetime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyItself());
    }

    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(particleLifetime);
        Destroy(gameObject);
    }
}
