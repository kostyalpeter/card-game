using UnityEngine;

public class ShopBuyCards : MonoBehaviour
{
    public CardStats cardStats;
    public void Buy()
    {
        if (gameObject.GetComponent<ShopCard>() == null)
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
        else if (gameObject.GetComponent<ShopCard>() != null)
        {
            var card = cardStats.GetComponent<CardUpgrade>();
            Card cards = cardStats.GetComponent<Card>();
            var shopCard = gameObject.GetComponent<ShopCard>();
            if (Shop.Gold >= 6)
            {
                if (shopCard.cardType == ShopCard.CardType.Purple)
                {
                    cards.locked = false;
                    card.cardUpgrades = CardUpgrade.CardUpgrades.PurpleGalaxy;
                    gameObject.SetActive(false);
                    Shop.Gold -= 6;
                }
                if (shopCard.cardType == ShopCard.CardType.Red)
                {
                    cards.locked = false;
                    card.cardUpgrades = CardUpgrade.CardUpgrades.RedGalaxy;
                    gameObject.SetActive(false);
                    Shop.Gold -= 6;
                }
                if (shopCard.cardType == ShopCard.CardType.Green)
                {
                    cards.locked = false;
                    card.cardUpgrades = CardUpgrade.CardUpgrades.GreenGalaxy;
                    gameObject.SetActive(false);
                    Shop.Gold -= 6;
                }
                if (shopCard.cardType == ShopCard.CardType.none)
                {
                    cards.locked = false;
                    card.cardUpgrades = CardUpgrade.CardUpgrades.none;
                    gameObject.SetActive(false);
                    Shop.Gold -= 4;
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
