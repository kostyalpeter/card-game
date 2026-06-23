using UnityEngine;
using System.Collections;

public class DoubleClick : MonoBehaviour
{
    int Clicks = 2;
    public float speed = 0.3f;
    CardPlacement cards;
    int currentCardIndex;
    UseCard useCard;

    void Start()
    {
        cards = FindAnyObjectByType<CardPlacement>();
        if (cards == null)
        {
            Debug.LogError("Error");
        }
    }

    void Update()
    {
        if (Clicks == 0)
        {
            Clicks = 2;
            Debug.Log("Click");
            if (gameObject.GetComponent<Card>().CardPlace == 1)
            {
                cards.CardPlace1.GetComponent<Place>().isTaken = false;
            }
            else if (gameObject.GetComponent<Card>().CardPlace == 2)
            {
                cards.CardPlace2.GetComponent<Place>().isTaken = false;
            }
            else if (gameObject.GetComponent<Card>().CardPlace == 3)
            {
                cards.CardPlace3.GetComponent<Place>().isTaken = false;
            }
            gameObject.SetActive(false);
            cards.RefreshBoard();
            gameObject.GetComponent<UseCard>().Use();
        }
    }

    public void Click()
    {
        Clicks -= 1;
        StartCoroutine(ResetClicks());
    }

    IEnumerator ResetClicks()
    {
        yield return new WaitForSeconds(speed);
        Clicks = 2;
    }
}
