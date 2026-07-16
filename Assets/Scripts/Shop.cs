using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Shop : MonoBehaviour
{
    public static int Gold;
    public TMP_Text GoldText;
    Time time;
    public GameObject game;
    public List<GameObject> UseCards = new List<GameObject>();
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
        UseCards[2].transform.position = startpos3;
        UseCards[3].transform.position = startpos4;
        DoubleClick.Countdown = false;
        Animations.Countdown2 = true;
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
            startpos3 = UseCards[2].transform.position;
            startpos4 = UseCards[3].transform.position;
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        UseCards[0].gameObject.SetActive(true);
        UseCards[1].gameObject.SetActive(true);
        UseCards[2].gameObject.SetActive(true);
        UseCards[3].gameObject.SetActive(true);
        UseCards[0].transform.position = ShopPos1.transform.position;
        UseCards[1].transform.position = ShopPos2.transform.position;
        UseCards[2].transform.position = ShopPos3.transform.position;
        UseCards[3].transform.position = ShopPos4.transform.position;
    }

}
