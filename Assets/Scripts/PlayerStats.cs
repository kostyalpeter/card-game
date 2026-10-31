using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int level = 1;
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

    public void AddLevel()
    {
        if (level < 9)
        {
            level++;
        }
    }
}
