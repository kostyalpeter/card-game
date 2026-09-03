using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Shop : MonoBehaviour
{
    public static int Gold;
    public TMP_Text GoldText;
    Time time;
    public GameObject game;
    public List<GameObject> UseCards = new List<GameObject>();
    public List<GameObject> Cards = new List<GameObject>();
    public GameObject ShopPos1;
    public GameObject ShopPos2;
    public GameObject ShopPos3;
    public GameObject ShopPos4;
    Vector3 startpos1;
    Vector3 startpos2;
    Vector3 startpos3;
    Vector3 startpos4;
    Transform pos;
    void Start()
    {
        time = GetComponent<Time>();
    }

    void Update()
    {
        GoldText.text = Gold.ToString("0");
    }
    public void AddGold()
    {
        Gold++;
    }

    public void Next()
    {
        time.Shop1.SetActive(false);
        game.SetActive(true);
        UseCards[0].transform.position = startpos1;
        UseCards[1].transform.position = startpos2;
        Cards[2].transform.position = startpos3;
        Cards[3].transform.position = startpos4;
        DoubleClick.Countdown = false;
    }
    public void StartShop()
    {
        if (UseCards.Count > 0)
        {
            for (int i = UseCards.Count - 1; i > 0; i--)
            {
                int randomindex = Random.Range(0, i + 1);
                GameObject ideiglenes = UseCards[i];
                UseCards[i] = UseCards[randomindex];
                UseCards[randomindex] = ideiglenes;
            }
            startpos1 = UseCards[0].transform.position;
            startpos2 = UseCards[1].transform.position;
        }
        if (Cards.Count > 0)
        {
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int randomindex2 = Random.Range(0, i + 1);
                GameObject ideiglenes2 = Cards[i];
                Cards[i] = Cards[randomindex2];
                Cards[randomindex2] = ideiglenes2;
            }
            startpos3 = Cards[2].transform.position;
            startpos4 = Cards[3].transform.position;
        }
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        UseCards[0].gameObject.SetActive(true);
        UseCards[1].gameObject.SetActive(true);
        Cards[2].gameObject.SetActive(true);
        Cards[3].gameObject.SetActive(true);
        UseCards[0].transform.position = ShopPos1.transform.position;
        UseCards[1].transform.position = ShopPos2.transform.position;
        Cards[2].transform.position = ShopPos3.transform.position;
        Cards[3].transform.position = ShopPos4.transform.position;

        {
            foreach (GameObject card in Cards)
            {
                Image[] images = card.GetComponentsInChildren<Image>(true);
                foreach (Image img in images)
                {
                    if (img.gameObject.name == "Image")
                    {
                        img.gameObject.SetActive(false);
                    }
                }
            }
        }

        var num = Random.Range(1, 21);

        if (num == 1)
        {
            GameObject targetCard = Cards[2];

            if (targetCard != null)
            {
                Image[] images = targetCard.GetComponentsInChildren<Image>(true);
                foreach (Image img in images)
                {
                    if (img.gameObject.name == "Image")
                    {
                        img.gameObject.SetActive(true);

                        Image Img2 = img.GetComponent<Image>();
                        Color tempColor1 = Color.purple;
                        tempColor1.a = 0.5f;
                        Color tempColor2 = Color.green;
                        tempColor2.a = 0.5f;
                        Color tempColor3 = Color.red;
                        tempColor3.a = 0.5f;

                        var num2 = Random.Range(1, 4);

                        ShopCard cardScript = targetCard.GetComponent<ShopCard>();

                        if (cardScript != null)
                        {
                            cardScript = img.gameObject.GetComponent<ShopCard>();

                        }
                        if (num2 == 1)
                        {
                            Img2.color = tempColor1;
                            if (cardScript != null) cardScript.cardType = ShopCard.CardType.Purple;
                        }
                        if (num2 == 2)
                        {
                            Img2.color = tempColor2;
                            if (cardScript != null) cardScript.cardType = ShopCard.CardType.Green;
                        }
                        if (num2 == 3)
                        {
                            Img2.color = tempColor3;
                            if (cardScript != null) cardScript.cardType = ShopCard.CardType.Red;
                        }
                    }
                }
            }
        }
    }
}