using Unity.VisualScripting;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public GameObject x1;
    public GameObject x2;
    public GameObject x3;
    public static bool Started;

    public void X1()
    {
        if(Started) return;
        CardPlacement.DiscardAmount = 5;

        x1.SetActive(true);
        x2.SetActive(false);
        x3.SetActive(false);
    }

    public void X2()
    {
        if(Started) return;
        CardPlacement.DiscardAmount = 3;

        x1.SetActive(false);
        x2.SetActive(true);
        x3.SetActive(false);
    }

    public void X3()
    {
        if(Started) return;
        CardPlacement.DiscardAmount = 1;

        x1.SetActive(false);
        x2.SetActive(false);
        x3.SetActive(true);
    }
}
