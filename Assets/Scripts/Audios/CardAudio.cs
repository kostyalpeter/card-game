using UnityEngine;

public class CardAudio : MonoBehaviour
{
    public AudioSource Src;
    public AudioClip Card1;
    public AudioClip Card2;

    public void CardPlay()
    {
        Src.PlayOneShot(Card1, Audio.Volume / 100f);
    }
    public void CardDiscard()
    {
        Src.PlayOneShot(Card2, Audio.Volume / 100f);
    }
}