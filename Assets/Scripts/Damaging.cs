using UnityEngine;

public class Damaging : MonoBehaviour
{
    public static int DamageAmount;
    public CardPlacement cardPlacement;
    public static int EnemyHp;
    private static int playerHp = 100;
    public static int MaxEnemyHp = 100;
    public static int MaxPlayerHp = 100;
    public static int PlayerHp
    {
        get => playerHp;
        set
        {
            playerHp = Mathf.Clamp(value, 0, MaxPlayerHp);
        }
    }
    public static bool Hurt;
    public static int EnemyDamageAmount;
    public bool canDamage;
    public static bool Hit;
    public static bool Asd;
    public static bool Enemy;
    public static bool Ulty = true;
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

        if (Hit)
        {
            PlayerDamage();
            Hit = false;
        }
    }
    public void Damage()
    {
        EnemyHp -= DamageAmount;
        Hurt = true;
        canDamage = true;
        Anim.CanHit = true;
        Debug.Log("Damage67");
        NonAttacks.DamageBoosted = false;
        NonAttacks.Oiled = false;
        NonAttacks.Watered = false;
    }

    public void Damage2()
    {
        if (NonAttacks.DamageBoosted == false)
        {
            EnemyHp -= 10;
        }
        if (NonAttacks.DamageBoosted == true)
        {
            EnemyHp -= 10 * 3;
        }
        Hurt = true;
        canDamage = true;
        Anim.CanHit = true;
        NonAttacks.DamageBoosted = false;
        NonAttacks.Oiled = false;
        NonAttacks.Watered = false;
    }
    public void NonAttack()
    {
        Enemy = true;
        Hurt = true;
        canDamage = true;
        Asd = true;
        Debug.Log("NonAttacked");
    }
    public void PlayerDamage()
    {
        if (canDamage && EnemyHp > 0)
        {
            EnemyDamageAmount = Random.Range(15, 26);

            if (UseCard.EnemyLevel == 1)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1;
            }
            else if (UseCard.EnemyLevel == 2)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.05;
            }
            else if (UseCard.EnemyLevel == 3)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.1;
            }
            else if (UseCard.EnemyLevel == 4)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.15;
            }
            else if (UseCard.EnemyLevel == 5)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.2;
            }
            else if (UseCard.EnemyLevel == 6)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.25;
            }
            else if (UseCard.EnemyLevel == 7)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.3;
            }
            else if (UseCard.EnemyLevel == 8)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.35;
            }
            else if (UseCard.EnemyLevel == 9)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)1.4;
            }

            Debug.Log(EnemyDamageAmount);

            if (Ulty == false)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1;
            }
            else if (Ulty == true)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 2;
            }

            if (NonAttacks.LessDamaged == false)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1;
            }
            else if (NonAttacks.LessDamaged == false)
            {
                EnemyDamageAmount = EnemyDamageAmount *= (int)0.5f;
            }

            if (NonAttacks.Shield != true)
            {
                PlayerHp -= EnemyDamageAmount;
                canDamage = false;
                Debug.Log("Enemy Attack");
                Debug.Log(EnemyDamageAmount);
            }


            var num = Random.Range(1, 11);
            if (num <= 2)
            {
                Ulty = true;
            }
            else if (num > 2)
            {
                Ulty = false;
            }
            NonAttacks.LessDamaged = false;
        }
    }
}