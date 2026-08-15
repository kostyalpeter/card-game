using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animations2 animations2;
    public Damaging damaging;
    public static bool CanHit = false;
    public void Ice()
    {
        animations2.ice.SetActive(false);
    }
    public void Lightning()
    {
        animations2.lightning.SetActive(false);
    }
    public void FireRain()
    {
        animations2.ice.SetActive(false);
    }
    public void Burst()
    {
        animations2.burst.SetActive(false);
    }
    public void Sword()
    {
        animations2.sword.SetActive(false);
    }
    public void FireBall()
    {
        animations2.fireBall.SetActive(false);
    }
    public void TheBlackArrow()
    {
        animations2.theBlackArrow.SetActive(false);
    }
    public void FireShots()
    {
        animations2.fireShots.SetActive(false);
    }
    public void ArrowRain()
    {
        animations2.arrowRain.SetActive(false);
    }
    public void ArrowShot()
    {
        animations2.arrowShot.SetActive(false);
    }

    public void Damage()
    {
        CanHit = true;
        damaging.Damage();
    }
}