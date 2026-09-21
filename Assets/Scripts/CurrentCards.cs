using System.Collections.Generic;
using UnityEngine;

public class CurrentCards : MonoBehaviour
{
    public GameObject Object;
    public GameObject CarddContainer;
    public List<GameObject> deckCards = new List<GameObject>();
    public RectTransform[] places;
    public void Click()
    {
        if (Object.activeSelf)
        {
            Object.SetActive(false);
        }
        else if (!Object.activeSelf)
        {
            Object.SetActive(true);
            Card();
        }
    }


    public void Card()
    {
        deckCards.Clear();
        int placesIndex = 0;

        foreach (Transform child in CarddContainer.transform)
        {
            var CardMenu = child.GetComponent<CardMenu>();
            if (CardMenu != null && CardMenu.Card != null && !CardMenu.Card.GetComponent<Card>().locked)
            {
                var cardScript = CardMenu.Card.GetComponent<Card>();
                if (cardScript != null && !cardScript.locked)
                {
                    deckCards.Add(child.gameObject);
                    if(placesIndex < places.Length)
                    {
                        child.GetComponent<RectTransform>().anchoredPosition = places[placesIndex].anchoredPosition;

                        placesIndex++;
                    }
                }
            }
        }
    }
}