using UnityEngine;

public class GameUIStart : MonoBehaviour
{
    public GameObject Play;
    bool showPlay;
    public int locked;
    public static int Set;
    public UseCard.Enemies enemies;

    void Update()
    {
        if (showPlay)
        {
            Play.SetActive(true);
        }
        if (!showPlay && Play != null)
        {
            Play.SetActive(false);
        }
    }

    public void Clicked()
    {
        if (Set >= locked)
        {
            showPlay = !showPlay;
        }
    }
    public void Test()
    {
        Set++;
    }

}