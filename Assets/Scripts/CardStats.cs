using UnityEngine;

public class CardStats : MonoBehaviour
{
    [SerializeField] private int cardLevel = 1;
    public int CardLevel 
    { 
        get => cardLevel; 
        set 
        {
            if (cardLevel != value)
            {
                cardLevel = value;
                CalculateDamage();
            }
        }
    }

    [SerializeField] private float baseDamage;
    public float CardDamage { get; private set; }

    void Awake()
    {
        CalculateDamage();
    }

    void CalculateDamage()
    {
        float multiplier = cardLevel switch
        {
            1 => 1.0f,
            2 => 1.1f,
            3 => 1.2f,
            4 => 1.3f,
            5 => 1.4f,
            6 => 1.5f,
            7 => 1.6f,
            8 => 1.7f,
            9 => 2.0f,
            _ => 1.0f
        };

        CardDamage = baseDamage * multiplier;
    }
}