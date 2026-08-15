using UnityEngine;

public class Click : MonoBehaviour
{
    public int Clicks = 2;
    public Animations2 animations2;

    void Update()
    {
        if (Clicks == 0)
        {
            Clicks = 2;
        }
    }

}
