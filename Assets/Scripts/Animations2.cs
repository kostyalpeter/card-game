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
        iceButton.GetComponent<Click>().Clicks--;
        if (iceButton.GetComponent<Click>().Clicks == 0)
        {
            ice.SetActive(true);
            ice.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void Lightning()
    {
        lightningButton.GetComponent<Click>().Clicks--;
        if (lightningButton.GetComponent<Click>().Clicks == 0)
        {
            lightning.SetActive(true);
            lightning.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void FireRain()
    {
        fireBallButton.GetComponent<Click>().Clicks--;
        if (fireBallButton.GetComponent<Click>().Clicks == 0)
        {
            FireRainBool = true;
        }
    }
    public void Burst()
    {
        burstButton.GetComponent<Click>().Clicks--;
        if (burstButton.GetComponent<Click>().Clicks == 0)
        {
            burst.SetActive(true);
            burst.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void Sword()
    {
        swordButton.GetComponent<Click>().Clicks--;
        if (swordButton.GetComponent<Click>().Clicks == 0)
        {
            sword.SetActive(true);
            sword.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void FireBall()
    {
        fireBallButton.GetComponent<Click>().Clicks--;
        if (fireBallButton.GetComponent<Click>().Clicks == 0)
        {
            fireBall.SetActive(true);
            fireBall.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void TheBlackArrow()
    {
        theBlackArrowButton.GetComponent<Click>().Clicks--;
        if (theBlackArrowButton.GetComponent<Click>().Clicks == 0)
        {
            theBlackArrow.SetActive(true);
            theBlackArrow.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    public void FireShots()
    {
        fireShotsButton.GetComponent<Click>().Clicks--;
        if (fireShotsButton.GetComponent<Click>().Clicks == 0)
        {
            FireShotsBool = true;
        }
    }
    public void ArrowRain()
    {
        arrowRainButton.GetComponent<Click>().Clicks--;
        if (arrowRainButton.GetComponent<Click>().Clicks == 0)
        {
            ArrowRainBool = true;
        }
    }
    public void ArrowShot()
    {
        arrowShotButton.GetComponent<Click>().Clicks--;
        if (arrowShotButton.GetComponent<Click>().Clicks == 0)
        {
            arrowShot.SetActive(true);
            arrowShot.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}