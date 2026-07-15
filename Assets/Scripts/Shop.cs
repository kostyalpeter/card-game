using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public static int Gold;
    public TMP_Text GoldText;
    Time time;
    public GameObject game;
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
        time.Shop.SetActive(false);
        game.SetActive(true);
    }
}
