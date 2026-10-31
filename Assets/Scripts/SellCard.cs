using UnityEngine;

public class SellCard : MonoBehaviour
{
    public GameObject Cards;
    public GameObject Box;

    public void Sell()
    {
        foreach (Transform child in Cards.transform)
        {
            CardAnimations cardAnim = child.GetComponent<CardAnimations>();
            if (cardAnim != null)
            {
                if (cardAnim.isSelected)
                {
                    if (GetComponent<CurrentCards>().placesIndex > 3)
                    {
                        CardTexts.ShowBool = false;
                        child.gameObject.GetComponent<CardMenu>().Card.GetComponent<Card>().locked = true;
                        GetComponent<CurrentCards>().placesIndex--;
                        child.gameObject.SetActive(false);
                        Shop.Gold += 2;
                        child.GetComponent<CardMenu>().Card.GetComponent<Card>().locked = true;
                    }
                }
            }
        }
    }
}
