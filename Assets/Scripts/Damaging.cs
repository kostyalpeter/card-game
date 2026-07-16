using UnityEngine;

public class Damaging : MonoBehaviour
{
    public static int DamageAmount;
    public CardPlacement cardPlacement;
    public static int EnemyHp;
    public static int PlayerHp;
    public static int MaxEnemyHp = 100;
    public static int MaxPlayerHp = 100;
    public static bool Hurt;
    public int EnemyDamageAmount = 20;
    public bool canDamage;
    void Start()
    {
        EnemyHp = MaxEnemyHp;
        PlayerHp = MaxPlayerHp;
    }

    void Update()
    {
        cardPlacement.EnemyHP.maxValue = MaxEnemyHp;
        cardPlacement.PlayerHP.maxValue = MaxPlayerHp;
        cardPlacement.EnemyHP.value = EnemyHp;
        cardPlacement.PlayerHP.value = PlayerHp;

    }
    public void Damage()
    {
        EnemyHp -= DamageAmount;
        Hurt = true;
        canDamage = true;
    }
    public void PlayerDamage()
    {
        if (canDamage && EnemyHp > 0)
        {
            if (UseCard.EnemyLevel == 1)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1;
            }
            if (UseCard.EnemyLevel == 2)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.15;
            }
            if (UseCard.EnemyLevel == 3)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.3;
            }
            if (UseCard.EnemyLevel == 4)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.45;
            }
            if (UseCard.EnemyLevel == 5)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.60;
            }
            if (UseCard.EnemyLevel == 6)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.75;
            }
            if (UseCard.EnemyLevel == 7)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 2;
            }
            if (UseCard.EnemyLevel == 8)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)2.5;
            }
            if (UseCard.EnemyLevel == 9)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 3;
            }
            PlayerHp -= EnemyDamageAmount;
            canDamage = false;
            Debug.Log("Enemy Attack");
        }
    }
}