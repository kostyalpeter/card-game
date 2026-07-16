using System.Collections.Generic;
using UnityEditor;
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
    public GameObject Game;
    public GameObject CardsGame;

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

    public void CardCall()
    {
        useCard.Starting();
        Game.SetActive(false);
        PlayerHP.gameObject.SetActive(true);
        EnemyHP.gameObject.SetActive(true);
        GamePlay.gameObject.SetActive(true);
        CardsGame.SetActive(true);
        foreach (Transform child in CardsGame.transform)
        {
            child.gameObject.SetActive(true);
        }
        Time.Timer = 35;

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
        GameObject FirstCard = Cards[0];
        while (currentCardIndex < Cards.Count && Cards[currentCardIndex].GetComponent<Card>().locked)
        {
            currentCardIndex++;
        }
        if (currentCardIndex < Cards.Count)
        {
            Cards[currentCardIndex].GetComponent<RectTransform>().anchoredPosition = Pos1; Cards[currentCardIndex].GetComponent<RectTransform>().rotation = Rot1;
            Cards[currentCardIndex].GetComponent<Card>().CardPlace = 1;
            CardPlace1.GetComponent<Place>().isTaken = true;
            currentCardIndex++;

        }
        while (currentCardIndex < Cards.Count && Cards[currentCardIndex].GetComponent<Card>().locked)
        {
            currentCardIndex++;
        }
        if (currentCardIndex < Cards.Count)
        {
            Cards[currentCardIndex].GetComponent<RectTransform>().anchoredPosition = Pos2; Cards[currentCardIndex].GetComponent<RectTransform>().rotation = Rot2;
            Cards[currentCardIndex].GetComponent<Card>().CardPlace = 2;
            CardPlace2.GetComponent<Place>().isTaken = true;
            currentCardIndex++;

        }
        while (currentCardIndex < Cards.Count && Cards[currentCardIndex].GetComponent<Card>().locked)
        {
            currentCardIndex++;
        }
        if (currentCardIndex < Cards.Count)
        {
            Cards[currentCardIndex].GetComponent<RectTransform>().anchoredPosition = Pos3; Cards[currentCardIndex].GetComponent<RectTransform>().rotation = Rot3;
            Cards[currentCardIndex].GetComponent<Card>().CardPlace = 3;
            CardPlace3.GetComponent<Place>().isTaken = true;
            currentCardIndex++;
        }
    }

    public void RefreshBoard()
    {
        Place Place1 = CardPlace1.GetComponent<Place>();
        Place Place2 = CardPlace2.GetComponent<Place>();
        Place Place3 = CardPlace3.GetComponent<Place>();

        if (Place1 && Place1.isTaken == false)
        {
            SkipCard();

            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();

                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos1;
                nextcard.GetComponent<RectTransform>().rotation = Rot1;

                nextcard.GetComponent<Card>().CardPlace = 1;
                Place1.isTaken = true;

                currentCardIndex++;
            }
        }
        if (Place2 && Place2.isTaken == false)
        {
            SkipCard();

            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();

                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos2;
                nextcard.GetComponent<RectTransform>().rotation = Rot2;

                nextcard.GetComponent<Card>().CardPlace = 2;
                Place2.isTaken = true;

                currentCardIndex++;
            }
        }
        if (Place3 && Place3.isTaken == false)
        {
            SkipCard();

            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();

                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos3;
                nextcard.GetComponent<RectTransform>().rotation = Rot3;

                nextcard.GetComponent<Card>().CardPlace = 3;
                Place3.isTaken = true;

                currentCardIndex++;
            }
        }
    }

    public void SkipCard()
    {
        while (currentCardIndex < Cards.Count && Cards[currentCardIndex].GetComponent<Card>().locked)
        {
            currentCardIndex++;
            continue;
        }
    }
}