using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPlacement : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
    public RectTransform CardPlace1;
    public RectTransform CardPlace2;
    public RectTransform CardPlace3;
    Vector2 Pos1;
    Vector2 Pos2;
    Vector2 Pos3;
    Quaternion Rot1;
    Quaternion Rot2;
    Quaternion Rot3;
    public int currentCardIndex;
    public GameObject Panel;
    public GameObject backGround;
    public GameObject playerCard;
    UseCard useCard;
    public Slider PlayerHP;
    public Slider EnemyHP;
    public GameObject GamePlay;
    public GameObject CardObject;
    public static int Discards = 3;

    public TMP_Text selected;
    public TMP_Text canplay;
    public TMP_Text cooldown;
    public TMP_Text countdown;
    public GameObject Game;
    public GameObject CurrentCards;

    void Start()
    {
        useCard = GetComponent<UseCard>();
        Pos1 = CardPlace1.anchoredPosition;
        Pos2 = CardPlace2.anchoredPosition;
        Pos3 = CardPlace3.anchoredPosition;
        Rot1 = CardPlace1.rotation;
        Rot2 = CardPlace2.rotation;
        Rot3 = CardPlace3.rotation;
    }

    void Update()
    {
        canplay.text = DoubleClick.canPlay.ToString();
        cooldown.text = DoubleClick.CoolDown.ToString();
        countdown.text = DoubleClick.Countdown.ToString();
    }

    public void CardCall()
    {
        CurrentCards.SetActive(true);
        Time.canTime = true;
        useCard.Starting();
        Panel.SetActive(false);
        backGround.SetActive(false);
        playerCard.SetActive(false);
        PlayerHP.gameObject.SetActive(true);
        EnemyHP.gameObject.SetActive(true);
        GamePlay.gameObject.SetActive(true);
        Time.Timer = 30;
        DoubleClick.CardPlays = DoubleClick.Amount;
        Game.SetActive(true);

        ResetAndRecallCards();
    }

    public void CardCall2()
    {
        if (Cards.Count > 0)
        {
            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                int randomindex = Random.Range(0, i + 1);
                GameObject ideiglenes = Cards[i];
                Cards[i] = Cards[randomindex];
                Cards[randomindex] = ideiglenes;
            }
        }

        currentCardIndex = 0;

        TryPlaceCardInSlot(CardPlace1, Pos1, Rot1, 1);
        TryPlaceCardInSlot(CardPlace2, Pos2, Rot2, 2);
        TryPlaceCardInSlot(CardPlace3, Pos3, Rot3, 3);

        CheckIfDeckEmpty();
    }

private void TryPlaceCardInSlot(RectTransform slotTransform, Vector2 pos, Quaternion rot, int placeIndex)
{
    if (slotTransform == null) return;

    Place placeScript = slotTransform.GetComponent<Place>();

    SkipCard();

    if (currentCardIndex < Cards.Count)
    {
        GameObject c = Cards[currentCardIndex];
        
        Card cardComp = c.GetComponent<Card>();
        if (cardComp != null && cardComp.locked)
        {
            currentCardIndex++;
            return;
        }

        c.SetActive(true);

        if (cardComp != null)
        {
            cardComp.CardPlace = placeIndex;
        }

        RectTransform cRect = c.GetComponent<RectTransform>();
        cRect.anchoredPosition = pos;
        cRect.rotation = rot;

        if (placeScript != null)
        {
            placeScript.isTaken = true;
        }

        currentCardIndex++;
    }
}
    public void RefreshBoard()
    {
        Place place1 = CardPlace1.GetComponent<Place>();
        Place place2 = CardPlace2.GetComponent<Place>();
        Place place3 = CardPlace3.GetComponent<Place>();

        if (place1 != null && !place1.isTaken)
        {
            TryPlaceCardInSlot(CardPlace1, Pos1, Rot1, 1);
        }

        if (place2 != null && !place2.isTaken)
        {
            TryPlaceCardInSlot(CardPlace2, Pos2, Rot2, 2);
        }

        if (place3 != null && !place3.isTaken)
        {
            TryPlaceCardInSlot(CardPlace3, Pos3, Rot3, 3);
        }

        CheckIfDeckEmpty();
    }

    private void CheckIfDeckEmpty()
    {
        SkipCard();

        bool p1Empty = CardPlace1 != null && !CardPlace1.GetComponent<Place>().isTaken;
        bool p2Empty = CardPlace2 != null && !CardPlace2.GetComponent<Place>().isTaken;
        bool p3Empty = CardPlace3 != null && !CardPlace3.GetComponent<Place>().isTaken;

        if (currentCardIndex >= Cards.Count && p1Empty && p2Empty && p3Empty)
        {
            ResetAndRecallCards();
        }
    }

public void SkipCard()
{
    while (currentCardIndex < Cards.Count)
    {
        GameObject current = Cards[currentCardIndex];

        if (current == null)
        {
            currentCardIndex++;
            continue;
        }

        Card cardComp = current.GetComponent<Card>();
        if (cardComp != null && cardComp.locked)
        {
            currentCardIndex++;
        }
        else
        {
            break;
        }
    }
}
    public void Discard()
    {
        DoubleClick[] allCards = CardObject.GetComponentsInChildren<DoubleClick>();
        bool needRefresh = false;

        foreach (DoubleClick card in allCards)
        {
            if (card.selected && Discards > 0)
            {
                card.selected = false;

                Card cardComp = card.gameObject.GetComponent<Card>();
                if (cardComp != null)
                {
                    if (cardComp.CardPlace == 1 && CardPlace1 != null) CardPlace1.GetComponent<Place>().isTaken = false;
                    else if (cardComp.CardPlace == 2 && CardPlace2 != null) CardPlace2.GetComponent<Place>().isTaken = false;
                    else if (cardComp.CardPlace == 3 && CardPlace3 != null) CardPlace3.GetComponent<Place>().isTaken = false;
                }

                card.gameObject.SetActive(false);

                Discards--;
                needRefresh = true;
            }
        }

        if (needRefresh)
        {
            RefreshBoard();
        }
    }

    public void CoolDown()
    {
        DoubleClick.CoolDown = false;
    }

    public void ResetAndRecallCards()
    {
        foreach (GameObject card in Cards)
        {
            if (card != null)
            {
                card.SetActive(false);
                Card c = card.GetComponent<Card>();
                if (c != null)
                {
                    c.locked = false;
                }
            }
        }

        if (CardPlace1 != null && CardPlace1.GetComponent<Place>() != null)
            CardPlace1.GetComponent<Place>().isTaken = false;

        if (CardPlace2 != null && CardPlace2.GetComponent<Place>() != null)
            CardPlace2.GetComponent<Place>().isTaken = false;

        if (CardPlace3 != null && CardPlace3.GetComponent<Place>() != null)
            CardPlace3.GetComponent<Place>().isTaken = false;

        CardCall2();
    }
}