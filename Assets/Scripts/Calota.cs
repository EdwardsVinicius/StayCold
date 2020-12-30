using UnityEngine;

public class Calota : MonoBehaviour
{
    public bool beingBuilt, beingMelted;

    private void Awake()
    {
        beingBuilt = false;
        beingMelted = false;
    }

    private void Update()
    {
        if (this.transform.position.y == 0f)
        {
            beingBuilt = false;
        }

        if (this.transform.position.y == -1f)
        {
            beingMelted = false;
        }
    }
}
