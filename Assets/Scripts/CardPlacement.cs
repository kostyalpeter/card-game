using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        Panel.SetActive(false);
        backGround.SetActive(false);
        playerCard.SetActive(false);

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
            CardPlace3.GetComponent<Place>().isTaken = true;
            currentCardIndex++;
        }
    }

    public void RefreshBoard()
    {
        Place Place1 = CardPlace1.GetComponent<Place>();
        Place Place2 = CardPlace2.GetComponent<Place>();
        Place Place3 = CardPlace3.GetComponent<Place>();


        if (Place1)
        {
            SkipCard();


            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();

                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos1;
                nextcard.GetComponent<RectTransform>().rotation = Rot1;

                nextcard.GetComponent<Card>().CardPlace = 1;

                currentCardIndex++;
            }
        }
        if (Place2)
        {

            SkipCard();

            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();


                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos2;
                nextcard.GetComponent<RectTransform>().rotation = Rot2;

                nextcard.GetComponent<Card>().CardPlace = 2;

                currentCardIndex++;
            }
        }
        if (Place3)
        {

            SkipCard();

            if (currentCardIndex < Cards.Count && !Cards[currentCardIndex].GetComponent<Card>().locked)
            {
                GameObject Nextcard = Cards[currentCardIndex];
                RectTransform nextcard = Nextcard.GetComponent<RectTransform>();


                nextcard.GetComponent<RectTransform>().anchoredPosition = Pos3;
                nextcard.GetComponent<RectTransform>().rotation = Rot3;

                nextcard.GetComponent<Card>().CardPlace = 3;

                currentCardIndex++;
            }
        }
    }

    void LateUpdate()
    {
        SkipCard();
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