using UnityEngine;

public class GameUIStart : MonoBehaviour
{
    public GameObject Play;
    bool showPlay;
    public int locked;
    [SerializeField] public static int Set;

    public void Clicked()
    {
        showPlay = !showPlay;
        if (showPlay && Set >= locked)
        {
            Play.SetActive(true);
        }
        if (!showPlay && Set >= locked)
        {
            Play.SetActive(false);
        }
    }
    public void Test()
    {
        Set++;
    }
}
