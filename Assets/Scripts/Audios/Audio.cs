using UnityEngine;

public class Audio : MonoBehaviour
{
    public PlayerAudio playerAudio;
    public static float Volume = 1;

    public void Fire()
    {
        if (playerAudio != null)
        {
            playerAudio.Fire();
        }
    }
    public void Fire2()
    {
        if (playerAudio != null)
        {
            playerAudio.Fire();
        }
    }
    public void ArrowHit()
    {
        if (playerAudio != null)
        {
            playerAudio.Arrow();
        }
    }
    public void ArrowShott()
    {
        if (playerAudio != null)
        {
            playerAudio.ArrowShot();
        }
    }
    public void Lightningg()
    {
        if (playerAudio != null)
        {
            playerAudio.Lightning();
        }
    }
    public void Burstt()
    {
        if (playerAudio != null)
        {
            playerAudio.Burstt();
        }
    }
    public void SwrodHitt()
    {
        if (playerAudio != null)
        {
            playerAudio.SwordHitt();
        }
    }
    public void Bite()
    {
        if (playerAudio != null)
        {
            playerAudio.Bite();
        }
    }
    public void ShieldHitt()
    {
        if (playerAudio != null)
        {
            playerAudio.ShieldHitt();
        }
    }
    public void IceShatter()
    {
        if (playerAudio != null)
        {
            playerAudio.IceShatter();
        }
    }
    public void Bow()
    {
        if (playerAudio != null)
        {
            playerAudio.Bow();
        }
    }
    public void CoolDown()
    {
        DoubleClick.CoolDown = false;
    }
}