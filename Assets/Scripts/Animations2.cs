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
    public GameObject water;
    public GameObject oil;
    public GameObject HpButton;
    public GameObject HealButton;
    public GameObject MoreXpButton;
    public GameObject MoreTimeButton;
    public GameObject LessDamageButton;
    public GameObject DamageBoostButton;
    public GameObject MoreGoldButton;
    public GameObject ShieldButton;
    public GameObject OilButton;
    public GameObject WaterButton;
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
        ice.SetActive(true);
        ice.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void Lightning()
    {
        lightning.SetActive(true);
        lightning.GetComponent<Animator>().SetTrigger("Attack");
    }

    public void FireRain()
    {
        FireRainBool = true;
    }
    public void Burst()
    {
        burst.SetActive(true);
        burst.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void Sword()
    {
        sword.SetActive(true);
        sword.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void FireBall()
    {
        fireBall.SetActive(true);
        fireBall.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void TheBlackArrow()
    {
        theBlackArrow.SetActive(true);
        theBlackArrow.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void FireShots()
    {
        FireShotsBool = true;
    }
    public void ArrowRain()
    {
        ArrowRainBool = true;
    }
    public void ArrowShot()
    {
        arrowShot.SetActive(true);
        arrowShot.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void Heal()
    {
        heal.SetActive(true);
        heal.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void MoreGold()
    {
        moreGold.SetActive(true);
        moreGold.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void DamageBoost()
    {
        damageBoost.SetActive(true);
        damageBoost.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void LessDamage()
    {
        lessDamage.SetActive(true);
        lessDamage.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void MoreXp()
    {
        moreXp.SetActive(true);
        moreXp.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void Shield()
    {
        shield.SetActive(true);
        NonAttacks.Shield = true;
        shield.GetComponent<NonAttacks>().Shieldd();
    }
    public void MoreTime()
    {
        moreTime.SetActive(true);
        moreTime.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void Hp()
    {
        hp.SetActive(true);
        hp.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void Water()
    {
        water.SetActive(true);
        water.GetComponent<Animator>().SetTrigger("Trigger");
    }
    public void Oil()
    {
        oil.SetActive(true);
        oil.GetComponent<Animator>().SetTrigger("Trigger");
    }
}