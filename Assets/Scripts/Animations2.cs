using UnityEngine;
using UnityEngine.UI;

public class Animations2 : MonoBehaviour
{
    public GameObject ice;
    public GameObject lightning;
    public GameObject fireRain;
    public GameObject burst;
    public GameObject sword;
    public GameObject fireBall;
    public GameObject theBlackArrow;
    public GameObject fireShots;
    public GameObject arrowRain;
    public GameObject arrowShot;
    public GameObject iceButton;
    public GameObject lightningButton;
    public GameObject fireRainButton;
    public GameObject burstButton;
    public GameObject swordButton;
    public GameObject fireBallButton;
    public GameObject theBlackArrowButton;
    public GameObject fireShotsButton;
    public GameObject arrowRainButton;
    public GameObject arrowShotButton;
    public bool FireRainBool;
    public bool FireShotsBool;
    public bool ArrowRainBool;



    public GameObject heal;
    public GameObject moreXp;
    public GameObject moreTime;
    public GameObject lessDamage;
    public GameObject damageBoost;
    public GameObject moreGold;
    public GameObject shield;
    public GameObject hp;
    public GameObject HpButton;
    public GameObject HealButton;
    public GameObject MoreXpButton;
    public GameObject MoreTimeButton;
    public GameObject LessDamageButton;
    public GameObject DamageBoostButton;
    public GameObject MoreGoldButton;
    public GameObject ShieldButton;
    Button btn;


    void Update()
    {
        if (FireRainBool)
        {
            if (!fireRain.activeSelf)
            {
                fireRain.SetActive(true);
                return;
            }
            Animator[] allChildren = fireRain.GetComponentsInChildren<Animator>();


            foreach (Animator child in allChildren)
            {
                child.SetTrigger("Attack");
                FireRainBool = false;
            }
        }
        if (FireShotsBool)
        {
            if (!fireShots.activeSelf)
            {
                fireShots.SetActive(true);
                return;
            }
            Animator[] allChildren = fireShots.GetComponentsInChildren<Animator>();


            foreach (Animator child in allChildren)
            {
                child.SetTrigger("Attack");
                FireShotsBool = false;
            }
        }
        if (ArrowRainBool)
        {
            if (!arrowRain.activeSelf)
            {
                arrowRain.SetActive(true);
                return;
            }
            Animator[] allChildren = arrowRain.GetComponentsInChildren<Animator>();


            foreach (Animator child in allChildren)
            {
                child.SetTrigger("Attack");
                ArrowRainBool = false;
            }
        }
    }

    public void Ice()
    {
        if (DoubleClick.Countdown == false)
        {
            iceButton.GetComponent<Click>().Clicks--;

            if (iceButton.GetComponent<Click>().Clicks == 0)
            {
                ice.SetActive(true);
                ice.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void Lightning()
    {
        if (DoubleClick.Countdown == false)
        {
            lightningButton.GetComponent<Click>().Clicks--;
            if (lightningButton.GetComponent<Click>().Clicks == 0)
            {
                lightning.SetActive(true);
                lightning.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void FireRain()
    {
        if (DoubleClick.Countdown == false)
        {
            fireBallButton.GetComponent<Click>().Clicks--;
            if (fireBallButton.GetComponent<Click>().Clicks == 0)
            {
                FireRainBool = true;
            }
        }
    }
    public void Burst()
    {
        if (DoubleClick.Countdown == false)
        {
            burstButton.GetComponent<Click>().Clicks--;
            if (burstButton.GetComponent<Click>().Clicks == 0)
            {
                burst.SetActive(true);
                burst.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void Sword()
    {
        if (DoubleClick.Countdown == false)
        {
            swordButton.GetComponent<Click>().Clicks--;
            if (swordButton.GetComponent<Click>().Clicks == 0)
            {
                sword.SetActive(true);
                sword.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void FireBall()
    {
        if (DoubleClick.Countdown == false)
        {
            fireBallButton.GetComponent<Click>().Clicks--;
            if (fireBallButton.GetComponent<Click>().Clicks == 0)
            {
                fireBall.SetActive(true);
                fireBall.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void TheBlackArrow()
    {
        if (DoubleClick.Countdown == false)
        {
            theBlackArrowButton.GetComponent<Click>().Clicks--;
            if (theBlackArrowButton.GetComponent<Click>().Clicks == 0)
            {
                theBlackArrow.SetActive(true);
                theBlackArrow.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void FireShots()
    {
        if (DoubleClick.Countdown == false)
        {
            fireShotsButton.GetComponent<Click>().Clicks--;
            if (fireShotsButton.GetComponent<Click>().Clicks == 0)
            {
                FireShotsBool = true;
            }
        }
    }
    public void ArrowRain()
    {
        if (DoubleClick.Countdown == false)
        {
            arrowRainButton.GetComponent<Click>().Clicks--;
            if (arrowRainButton.GetComponent<Click>().Clicks == 0)
            {
                ArrowRainBool = true;
            }
        }
    }
    public void ArrowShot()
    {
        if (DoubleClick.Countdown == false)
        {
            arrowShotButton.GetComponent<Click>().Clicks--;
            if (arrowShotButton.GetComponent<Click>().Clicks == 0)
            {
                arrowShot.SetActive(true);
                arrowShot.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
    public void Heal()
    {
        if (DoubleClick.Countdown == false)
        {
            HealButton.GetComponent<Click>().Clicks--;
            if (HealButton.GetComponent<Click>().Clicks == 0)
            {
                heal.SetActive(true);
                heal.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void MoreGold()
    {
        if (DoubleClick.Countdown == false)
        {
            MoreGoldButton.GetComponent<Click>().Clicks--;
            if (MoreGoldButton.GetComponent<Click>().Clicks == 0)
            {
                moreGold.SetActive(true);
                moreGold.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void DamageBoost()
    {
        if (DoubleClick.Countdown == false)
        {
            DamageBoostButton.GetComponent<Click>().Clicks--;
            if (DamageBoostButton.GetComponent<Click>().Clicks == 0)
            {
                damageBoost.SetActive(true);
                damageBoost.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void LessDamage()
    {
        if (DoubleClick.Countdown == false)
        {
            LessDamageButton.GetComponent<Click>().Clicks--;
            if (LessDamageButton.GetComponent<Click>().Clicks == 0)
            {
                lessDamage.SetActive(true);
                lessDamage.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void MoreXp()
    {
        if (DoubleClick.Countdown == false)
        {
            MoreXpButton.GetComponent<Click>().Clicks--;
            if (MoreXpButton.GetComponent<Click>().Clicks == 0)
            {
                moreXp.SetActive(true);
                moreXp.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void Shield()
    {
        if (DoubleClick.Countdown == false)
        {
            ShieldButton.GetComponent<Click>().Clicks--;
            if (ShieldButton.GetComponent<Click>().Clicks == 0)
            {
                shield.SetActive(true);
                NonAttacks.Shield = true;
                shield.GetComponent<NonAttacks>().Shieldd();
            }
        }
    }
    public void MoreTime()
    {
        if (DoubleClick.Countdown == false)
        {
            MoreTimeButton.GetComponent<Click>().Clicks--;
            if (MoreTimeButton.GetComponent<Click>().Clicks == 0)
            {
                moreTime.SetActive(true);
                moreTime.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
    public void Hp()
    {
        if (DoubleClick.Countdown == false)
        {
            HpButton.GetComponent<Click>().Clicks--;
            if (HpButton.GetComponent<Click>().Clicks == 0)
            {
                hp.SetActive(true);
                hp.GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }
}