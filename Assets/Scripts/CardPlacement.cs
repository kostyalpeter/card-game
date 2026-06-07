using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject >();
    public RectTransform CardPlace1;
    public RectTransform CardPlace2;
    public RectTransform CardPlace3;
    Vector2 Pos1;
    Vector2 Pos2;
    Vector2 Pos3;


    void Start()
    {
        Pos1 = CardPlace1.anchoredPosition;
        Pos2 = CardPlace2.anchoredPosition;
        Pos3 = CardPlace3.anchoredPosition;
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
        Cards[0].GetComponent<RectTransform>().anchoredPosition = Pos1;
        Cards[1].GetComponent<RectTransform>().anchoredPosition = Pos2;
    }
}