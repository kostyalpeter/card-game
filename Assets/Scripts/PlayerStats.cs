using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static int level = 1;
    public RectTransform lvl1;
    public RectTransform lvl2;
    public RectTransform lvl3;
    public RectTransform lvl4;
    public RectTransform lvl5;
    public RectTransform lvl6;
    public RectTransform lvl7;
    public RectTransform lvl8;
    public RectTransform lvl9;

    void Start()
    {

    }

    void Update()
    {
        if (level == 1)
        {
            lvl1.gameObject.SetActive(true);
        }
        if (level == 2)
        {
            lvl2.gameObject.SetActive(true);
        }
        if (level == 3)
        {
            lvl3.gameObject.SetActive(true);
        }
        if (level == 4)
        {
            lvl4.gameObject.SetActive(true);
        }
        if (level == 5)
        {
            lvl5.gameObject.SetActive(true);
        }
        if (level == 6)
        {
            lvl6.gameObject.SetActive(true);
        }
        if (level == 7)
        {
            lvl7.gameObject.SetActive(true);
        }
        if (level == 8)
        {
            lvl8.gameObject.SetActive(true);
        }
        if (level == 9)
        {
            lvl9.gameObject.SetActive(true);
        }
    }
    public void AddLevel()
    {
        if (level < 9)
        {
            level++;
        }
    }
}
