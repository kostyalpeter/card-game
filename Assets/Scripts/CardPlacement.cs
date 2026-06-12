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

    void Start()
    {
        Pos1 = CardPlace1.anchoredPosition;
        Pos2 = CardPlace2.anchoredPosition;
        Pos3 = CardPlace3.anchoredPosition;
        Rot1 = CardPlace1.rotation;
        Rot2 = CardPlace2.rotation;
        Rot3 = CardPlace3.rotation;
    }

    public void CardCall()
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

        if (currentCardIndex <= Cards.Count)

        {

            GameObject NextCard = Cards[currentCardIndex];

            RectTransform nextCard = NextCard.GetComponent<RectTransform>();

            nextCard.GetComponent<Card>();

            if (nextCard.GetComponent<Card>().locked == false)

            {

                if (CardPlace1.GetComponent<Place>().isTaken == false)

                {

                    nextCard.position = CardPlace1.position;

                    nextCard.rotation = CardPlace1.rotation;

                    nextCard.GetComponent<Card>().CardPlace = 1;

                }

                else if (CardPlace1.GetComponent<Place>().isTaken == true)

                {

                    if (CardPlace2.GetComponent<Place>().isTaken == false)

                    {

                        nextCard.position = CardPlace2.position;

                        nextCard.rotation = CardPlace2.rotation;

                        nextCard.GetComponent<Card>().CardPlace = 2;

                    }

                    else if (CardPlace2.GetComponent<Place>().isTaken == true)

                    {

                        nextCard.position = CardPlace3.position;

                        nextCard.rotation = CardPlace3.rotation;

                        nextCard.GetComponent<Card>().CardPlace = 3;

                    }

                }

                currentCardIndex++;

                Debug.Log("card");

            }

            else

            {

                currentCardIndex++;

                Debug.Log("card skipped");

            }

        }

    }

}