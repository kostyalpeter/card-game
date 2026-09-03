using UnityEngine;
using System.Collections;
using TMPro;

public class DoubleClick : MonoBehaviour
{
    int Clicks = 2;
    public float speed = 0.3f;
    CardPlacement cards;
    int currentCardIndex;
    UseCard useCard;
    public GameObject Player;
    public static bool Countdown;
    public Damaging damaging;
    public enum Cards { Shoot, Walk, NonAttack };
    public Cards cardType;
    public TMP_Text Text;
    public Damaging damage;
    void Start()
    {
        cards = FindAnyObjectByType<CardPlacement>();
        if (cards == null)
        {
            Debug.LogError("Error");
        }
        useCard = GetComponent<UseCard>();
    }

    void Update()
    {
        if (Countdown)
        {
            Text.text = "True";
        }
        else
        {
            Text.text = "False";
        }

        if (Clicks == 0 && Countdown == false)
        {
            Countdown = true;
            Clicks = 2;
            Debug.Log("Click");
            if (gameObject.GetComponent<Card>().CardPlace == 1)
            {
                cards.CardPlace1.GetComponent<Place>().isTaken = false;
            }
            else if (gameObject.GetComponent<Card>().CardPlace == 2)
            {
                cards.CardPlace2.GetComponent<Place>().isTaken = false;
            }
            else if (gameObject.GetComponent<Card>().CardPlace == 3)
            {
                cards.CardPlace3.GetComponent<Place>().isTaken = false;
            }
            cards.RefreshBoard();
            useCard.DamageAmountSet();
            gameObject.GetComponent<UseCard>().Use();
            gameObject.GetComponent<CardUpgrade>().CardUpgradeCheck();
            if (cardType == Cards.Shoot)
            {
                Player.GetComponent<Animator>().SetTrigger("Shoot");
            }
            else if (cardType == Cards.Walk)
            {
                Player.GetComponent<Animator>().SetTrigger("Walk");
            }
            else if (cardType == Cards.NonAttack)
            {
            }
            var c = gameObject.GetComponent<CardUpgrade>();
            if (c.cardUpgrades == CardUpgrade.CardUpgrades.PurpleGalaxy)
            {

            }
            else if (c.cardUpgrades == CardUpgrade.CardUpgrades.RedGalaxy)
            {
                damage.Damage2();
            }
            else if (c.cardUpgrades == CardUpgrade.CardUpgrades.GreenGalaxy)
            {

            }   
            else { }
            gameObject.SetActive(false);
        }
    }

    public void Click()
    {
        if (Countdown == false)
        {
            Clicks -= 1;
            StartCoroutine(ResetClicks());
        }
    }

    public IEnumerator ResetClicks()
    {
        yield return new WaitForSeconds(speed);
        Clicks = 2;
    }
}
