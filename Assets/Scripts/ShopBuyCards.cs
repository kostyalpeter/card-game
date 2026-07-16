using UnityEngine;

public class ShopBuyCards : MonoBehaviour
{
    public CardStats cardStats;
    public void Buy()
    {
        if (cardStats.CardLevel < 9)
        {
            if (cardStats.CardLevel == 0)
            {
                if (Shop.Gold >= 3)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 1)
            {
                if (Shop.Gold >= 3)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 2)
            {
                if (Shop.Gold >= 3)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 3)
            {
                if (Shop.Gold >= 4)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 4)
            {
                if (Shop.Gold >= 4)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 5)
            {
                if (Shop.Gold >= 4)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 6)
            {
                if (Shop.Gold >= 5)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 7)
            {
                if (Shop.Gold >= 5)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
            else if (cardStats.CardLevel == 8)
            {
                if (Shop.Gold >= 5)
                {
                    Purchase();
                    Shop.Gold -= 3;
                }
            }
        }
    }

    public void Purchase()
    {
        cardStats.CardLevel++;
        Debug.Log("Card Bought");
        gameObject.SetActive(false);
    }
}
