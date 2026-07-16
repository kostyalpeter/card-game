using UnityEngine;

public class CardStats : MonoBehaviour
{
    public int CardLevel;
    public float CardDamage;
    void Update()
    {
        if(CardLevel == 1)
        {
            CardDamage *= 1.1f;
        }
        if(CardLevel == 2)
        {
            CardDamage *= 1.2f;
        }
        if(CardLevel == 3)
        {
            CardDamage *= 1.3f;
        }
        if(CardLevel == 4)
        {
            CardDamage *= 1.4f;
        }
        if(CardLevel == 5)
        {
            CardDamage *= 1.5f;
        }
        if(CardLevel == 6)
        {
            CardDamage *= 1.6f;
        }
        if(CardLevel == 7)
        {
            CardDamage *= 1.7f;
        }
        if(CardLevel == 8)
        {
            CardDamage *= 1.8f;
        }
        if(CardLevel == 9)
        {
            CardDamage *= 1.9f;
        }
    }
}
