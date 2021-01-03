using UnityEngine;

public class MeltingIce : MonoBehaviour
{
    public float timer = 0f;
    public float limitTimer = 5f;

    public Vector3 sink;
    // public bool stillGoing;

    public static bool beingBuilt, beingMelted;

    void Update()
    {
        /*
        Debug.Log(CalotasControllers.goingUp);
        if (CalotasControllers.goingUp == false)
        {
            timer += Time.deltaTime;

            if (timer >= limitTimer)
            {
                gameObject.transform.position += sink;
                //box2d.size += boxIncrease;
                timer = 0f;

                if (gameObject.transform.position.y <= -1)
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        LeanTween.moveLocalY(this.gameObject, -1f, 1f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                        gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
        }
        */
        
        /*
        if (stillGoing)
        {
            if (gameObject.transform.position.y >= 0)
            {
                //print("PARA TUDO PARA TUDO");
                gameObject.transform.position = new Vector3(0, 0, 0);
                sink = new Vector3(0, 0, 0);
                stillGoing = false;
            }
            else
            {
                gameObject.transform.position += sink;
            }
        }
        */
    }
}
