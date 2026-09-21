using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animations2 animations2;
    public Damaging damaging;
    public static bool CanHit = false;
    public void Ice()
    {
        DoubleClick.CoolDown = false;
        animations2.ice.SetActive(false);
    }
    public void Lightning()
    {
        DoubleClick.CoolDown = false;
        animations2.lightning.SetActive(false);
    }
    public void FireRain()
    {
        DoubleClick.CoolDown = false;
        animations2.ice.SetActive(false);
    }
    public void Burst()
    {
        DoubleClick.CoolDown = false;
        animations2.burst.SetActive(false);
    }
    public void Sword()
    {
        DoubleClick.CoolDown = false;
        animations2.sword.SetActive(false);
    }
    public void FireBall()
    {
        DoubleClick.CoolDown = false;
        animations2.fireBall.SetActive(false);
    }
    public void TheBlackArrow()
    {
        DoubleClick.CoolDown = false;
        animations2.theBlackArrow.SetActive(false);
    }
    public void FireShots()
    {
        DoubleClick.CoolDown = false;
        animations2.fireShots.SetActive(false);
    }
    public void ArrowRain()
    {
        DoubleClick.CoolDown = false;
        animations2.arrowRain.SetActive(false);
    }
    public void ArrowShot()
    {
        DoubleClick.CoolDown = false;
        animations2.arrowShot.SetActive(false);
    }

    public void Damage()
    {
        damaging.Damage();
        Damaging.Asd = true;
    }
}