using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource Src;
    public AudioClip Click;
    public GameObject X1;
    public GameObject X2;

    public void Sound()
    {
        Src.PlayOneShot(Click, Audio.Volume / 100f);
    }

    public void Cross()
    {
        if (X1 != null || X2 != null)
        {
            if (X1.activeSelf)
            {
                X1.SetActive(false);
                X2.SetActive(false);
                Console.console = false;
            }
            else if (!X1.activeSelf)
            {
                X1.SetActive(true);
                X2.SetActive(true); 
                Console.console = true;
            }
        }
    }
}