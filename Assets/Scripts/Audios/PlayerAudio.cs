using UnityEngine;
using UnityEngine.UI;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource Src;

    public AudioClip Burst;
    public AudioClip Drink1;
    public AudioClip Drink2;
    public AudioClip Fire1;
    public AudioClip Fire2;
    public AudioClip Fire3;
    public AudioClip IceShatter1;
    public AudioClip IceShatter2;
    public AudioClip ShieldHit1;
    public AudioClip ShieldHit2;
    public AudioClip Splash1;
    public AudioClip WaterFlow1;
    public AudioClip Arrow1;
    public AudioClip ArrowHit1;
    public AudioClip ArrowHit2;
    public AudioClip Lightning1;
    public AudioClip Lightning2;
    public AudioClip SwordHit1;
    public AudioClip SwordHit2;
    public AudioClip SwordHit3;
    public AudioClip SwrodThrow1;
    public AudioClip Break1;
    public AudioClip Bite1;
    public AudioClip Bow1;
    public Slider AudioSlider;

    public void Update()
    {
        Audio.Volume = AudioSlider.value * 100f;
    }

    public void Fire()
    {
        var num = Random.Range(1, 4);
        if (num == 1)
        {
            Src.PlayOneShot(Fire1, Audio.Volume / 100f);
        }
        else if (num == 2)
        {
            Src.PlayOneShot(Fire2, Audio.Volume / 100f);
        }
        else if (num == 3)
        {
            Src.PlayOneShot(Fire3, Audio.Volume / 100f);
        }
    }
    public void Drink()
    {
        var num = Random.Range(1, 3);
        if (num == 1)
        {
            Src.PlayOneShot(Drink1, Audio.Volume / 100f);
        }
        else if (num == 2)
        {
            Src.PlayOneShot(Drink2, Audio.Volume / 100f);
        }
    }
    public void Splash()
    {
        Src.PlayOneShot(Splash1, Audio.Volume / 100f);
    }
    public void Flow()
    {
        Src.PlayOneShot(WaterFlow1, Audio.Volume / 100f);
    }
    public void Burstt()
    {
        Src.PlayOneShot(Burst, Audio.Volume / 100f);
    }
    public void Lightning()
    {
        Src.PlayOneShot(Lightning1, Audio.Volume / 100f);
    }
    public void Arrow()
    {
        Src.PlayOneShot(ArrowHit1, Audio.Volume / 100f);
    }
    public void ArrowShot()
    {
        Src.PlayOneShot(Arrow1, Audio.Volume / 100f);
    }
    public void SwordHitt()
    {
        var num = Random.Range(1, 4);
        if (num == 1)
        {
            Src.PlayOneShot(SwordHit1, Audio.Volume / 100f);
        }
        else if (num == 2)
        {
            Src.PlayOneShot(SwordHit2, Audio.Volume / 100f);
        }
        else if (num == 3)
        {
            Src.PlayOneShot(SwordHit3, Audio.Volume / 100f);
        }
    }
    public void SwordThroww()
    {
        Src.PlayOneShot(SwrodThrow1, Audio.Volume / 100f);
    }
    public void Break()
    {
        Src.PlayOneShot(Break1, Audio.Volume / 100f);
    }
    public void Bite()
    {
        Src.PlayOneShot(Bite1, Audio.Volume / 100f);
    }
    public void ShieldHitt()
    {
        var num = Random.Range(1, 3);
        if (num == 1)
        {
            Src.PlayOneShot(ShieldHit1, Audio.Volume / 100f);
        }
        else if (num == 2)
        {
            Src.PlayOneShot(ShieldHit2, Audio.Volume / 100f);
        }
    }
    public void IceShatter()
    {
        var num = Random.Range(1, 3);
        if (num == 1)
        {
            Src.PlayOneShot(IceShatter1, Audio.Volume / 100f);
        }
        else if (num == 2)
        {
            Src.PlayOneShot(IceShatter2, Audio.Volume / 100f);
        }
    }
    public void Bow()
    {
        Src.PlayOneShot(Bow1, Audio.Volume / 100f);
    }
}