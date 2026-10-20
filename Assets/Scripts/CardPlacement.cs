using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPlacement : MonoBehaviour, ISaveable
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
    public static int Discards = DiscardAmount;
    public TMP_Text DiscardsText;
    public static int DiscardAmount = 3;

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
        DiscardsText.text = "Discards remaining: " + Discards;
    }

    public void CardCall()
    {
        Difficulty.Started = true;
        Discards = DiscardAmount;
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

        CardCall2();
    }

    public void CardCall2()
    {
        if (Cards.Count > 0)
        {
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int randomindex = Random.Range(0, i + 1);
                GameObject ideiglenes = Cards[i];
                Cards[i] = Cards[randomindex];
                Cards[randomindex] = ideiglenes;
            }
        }

        currentCardIndex = 0;

        SkipCard();
        if (currentCardIndex < Cards.Count)
        {
            GameObject c = Cards[currentCardIndex];
            c.SetActive(true);
            c.GetComponent<RectTransform>().anchoredPosition = Pos1;
            c.GetComponent<RectTransform>().rotation = Rot1;
            c.GetComponent<Card>().CardPlace = 1;
            CardPlace1.GetComponent<Place>().isTaken = true;
            currentCardIndex++;
        }

        SkipCard();
        if (currentCardIndex < Cards.Count)
        {
            GameObject c = Cards[currentCardIndex];
            c.SetActive(true);
            c.GetComponent<RectTransform>().anchoredPosition = Pos2;
            c.GetComponent<RectTransform>().rotation = Rot2;
            c.GetComponent<Card>().CardPlace = 2;
            CardPlace2.GetComponent<Place>().isTaken = true;
            currentCardIndex++;
        }

        SkipCard();
        if (currentCardIndex < Cards.Count)
        {
            GameObject c = Cards[currentCardIndex];
            c.SetActive(true);
            c.GetComponent<RectTransform>().anchoredPosition = Pos3;
            c.GetComponent<RectTransform>().rotation = Rot3;
            c.GetComponent<Card>().CardPlace = 3;
            CardPlace3.GetComponent<Place>().isTaken = true;
            currentCardIndex++;
        }

        CheckIfDeckEmpty();
    }

    public void RefreshBoard()
    {
        Place place1 = CardPlace1.GetComponent<Place>();
        Place place2 = CardPlace2.GetComponent<Place>();
        Place place3 = CardPlace3.GetComponent<Place>();

        if (place1 != null && !place1.isTaken)
        {
            SkipCard();
            if (currentCardIndex < Cards.Count)
            {
                GameObject nextCard = Cards[currentCardIndex];
                nextCard.SetActive(true);
                RectTransform nextRect = nextCard.GetComponent<RectTransform>();
                nextRect.anchoredPosition = Pos1;
                nextRect.rotation = Rot1;
                nextCard.GetComponent<Card>().CardPlace = 1;
                place1.isTaken = true;
                currentCardIndex++;
            }
        }

        if (place2 != null && !place2.isTaken)
        {
            SkipCard();
            if (currentCardIndex < Cards.Count)
            {
                GameObject nextCard = Cards[currentCardIndex];
                nextCard.SetActive(true);
                RectTransform nextRect = nextCard.GetComponent<RectTransform>();
                nextRect.anchoredPosition = Pos2;
                nextRect.rotation = Rot2;
                nextCard.GetComponent<Card>().CardPlace = 2;
                place2.isTaken = true;
                currentCardIndex++;
            }
        }

        if (place3 != null && !place3.isTaken)
        {
            SkipCard();
            if (currentCardIndex < Cards.Count)
            {
                GameObject nextCard = Cards[currentCardIndex];
                nextCard.SetActive(true);
                RectTransform nextRect = nextCard.GetComponent<RectTransform>();
                nextRect.anchoredPosition = Pos3;
                nextRect.rotation = Rot3;
                nextCard.GetComponent<Card>().CardPlace = 3;
                place3.isTaken = true;
                currentCardIndex++;
            }
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
        while (currentCardIndex < Cards.Count &&
               Cards[currentCardIndex] != null &&
               Cards[currentCardIndex].GetComponent<Card>() != null &&
               Cards[currentCardIndex].GetComponent<Card>().locked)
        {
            currentCardIndex++;
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
                    if (cardComp.CardPlace == 1) CardPlace1.GetComponent<Place>().isTaken = false;
                    else if (cardComp.CardPlace == 2) CardPlace2.GetComponent<Place>().isTaken = false;
                    else if (cardComp.CardPlace == 3) CardPlace3.GetComponent<Place>().isTaken = false;
                }

                card.transform.SetParent(null);
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
                if (CardObject != null)
                {
                    card.transform.SetParent(CardObject.transform, false);
                }
                card.SetActive(false);
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

    public void SaveData(Save data)
    {
        data.CardOrder.Clear();

        for(int i = 0; i < Cards.Count; i++)
        {
            data.CardOrder.Add(Cards[i].name);
        }
    }

    public void LoadData(Save data)
    {
        if(data.CardOrder == null || data.CardOrder.Count == 0) return;

        List<GameObject> reorderedList = new List<GameObject>();
        foreach (string cardName in data.CardOrder)
        {
            GameObject foundCard = Cards.Find(c => c.name == cardName);

            if(foundCard != null)
            {
                reorderedList.Add(foundCard);
            }
        }

        Cards = reorderedList;
    }

}