using UnityEngine;
using System.Collections;

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
    public enum Cards { Shoot, Walk };
    public Cards cardType;
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
        if (Clicks == 0 && Countdown == false)
        {
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
            if (cardType == Cards.Shoot)
            {
                Player.GetComponent<Animator>().SetTrigger("Shoot");
            }
            else if (cardType == Cards.Walk)
            {
                Player.GetComponent<Animator>().SetTrigger("Walk");
            }
            Countdown = true;
            Debug.Log(Countdown);
            gameObject.SetActive(false);
        }
    }

    public void Click()
    {
        Clicks -= 1;
        StartCoroutine(ResetClicks());
    }

    public IEnumerator ResetClicks()
    {
        yield return new WaitForSeconds(speed);
        Clicks = 2;
    }
}
