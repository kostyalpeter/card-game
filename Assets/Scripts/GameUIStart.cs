using UnityEngine;

public class GameUIStart : MonoBehaviour
{
    public GameObject Play;
    bool showPlay;

    public void Clicked()
    {
        showPlay = !showPlay;
        if (showPlay)
        {
            Play.SetActive(true);
        }
        if (!showPlay)
        {
            Play.SetActive(false);
        }
    }
}
