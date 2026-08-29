using UnityEngine;
using UnityEngine.UI;

public class CardUpgrade : MonoBehaviour
{
    public enum CardUpgrades
    {
        PurpleGalaxy,
        RedGalaxy,
        GreenGalaxy,
        none
    }

    public CardUpgrades cardUpgrades;

    public GameObject Object;
    private Vector2 Offset = new Vector2(-1.1299f, 1.068f);
    public static bool Starting;


    void Start()
    {
        Transform childTransform = transform.Find("Image");
        GameObject ChildObject = childTransform.gameObject;
        ChildObject.SetActive(false);
    }

    void Update()
    {
        if (Starting)
        {
            Check();
        }
    }
    public void CardUpgradeCheck()
    {
        if (cardUpgrades == CardUpgrades.none)
        {

        }
        else if (cardUpgrades == CardUpgrades.PurpleGalaxy)
        {
            Check();
        }
        else if (cardUpgrades == CardUpgrades.RedGalaxy)
        {
            Check();
        }
        else if (cardUpgrades == CardUpgrades.GreenGalaxy)
        {
            Check();
        }
    }

    public void Check()
    {
        if(cardUpgrades == CardUpgrades.none)
        {
            return;
        }
        Transform childTransform = transform.Find("Image");
        GameObject ChildObject = childTransform.gameObject;
        ChildObject.SetActive(true);

        if (cardUpgrades == CardUpgrades.PurpleGalaxy)
        {
            Image img = ChildObject.GetComponent<Image>();
            Color tempColor = Color.purple;
            tempColor.a = 0.5f;
            img.color = tempColor;
        }
        else if (cardUpgrades == CardUpgrades.RedGalaxy)
        {
            Image img = ChildObject.GetComponent<Image>();
            Color tempColor = Color.red;
            tempColor.a = 0.5f;
            img.color = tempColor;
        }
        else if (cardUpgrades == CardUpgrades.GreenGalaxy)
        {
            Image img = ChildObject.GetComponent<Image>();
            Color tempColor = Color.green;
            tempColor.a = 0.5f;
            img.color = tempColor;
        }
    }
}
