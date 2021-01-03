using UnityEngine;

public class Calota : MonoBehaviour
{
    public bool beingBuilt;
    public bool beingMelted;

    private void Awake()
    {
        beingBuilt = false;
        beingMelted = false;
    }

    private void Update()
    {
        if (transform.position.y == 0f)
        {
            beingBuilt = false;
        }

        /*
        Faz com q o render mesh seja desativado só depois de certa posição

        if(transform.position.y == -0.5f)
        {
            Debug.Log(gameObject.name);
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                // ativa o trigger para q o urso possa detectar colisao com a calota derretida
                gameObject.transform.GetChild(i).GetComponent<MeshCollider>().isTrigger = true;
            }
        }
        */

        if (transform.position.y == -1f)
        {
            beingMelted = false;
            FindObjectOfType<CalotasControllers>().gameObject.GetComponent<CalotasControllers>().haveOneMelting = false;
        }
    }
}
