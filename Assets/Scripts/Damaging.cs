using UnityEngine;

public class Damaging : MonoBehaviour, ISaveable
{
    public static float DamageAmount;
    public CardPlacement cardPlacement;
    public static float EnemyHp
    {
        get => enemyHp;
        set
        {
            enemyHp = Mathf.Clamp(value, 0, MaxEnemyHp);
        }
    }
    public static float enemyHp;
    private static float playerHp = 100;
    public static float MaxEnemyHp;
    public static float MaxPlayerHp = 100;
    public static float PlayerHp
    {
        get => playerHp;
        set
        {
            playerHp = Mathf.Clamp(value, 0, MaxPlayerHp);
        }
    }
    public static bool Hurt;
    public static float EnemyDamageAmount;
    public bool canDamage;
    public static bool Hit;
    public static bool Asd;
    public static bool Enemy;
    public static bool Ulty;
    void Start()
    {
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
                EnemyDamageAmount = EnemyDamageAmount *= 1.05f;
            }
            else if (UseCard.EnemyLevel == 3)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.1f;
            }
            else if (UseCard.EnemyLevel == 4)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.15f;
            }
            else if (UseCard.EnemyLevel == 5)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.2f;
            }
            else if (UseCard.EnemyLevel == 6)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.25f;
            }
            else if (UseCard.EnemyLevel == 7)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.3f;
            }
            else if (UseCard.EnemyLevel == 8)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.35f;
            }
            else if (UseCard.EnemyLevel == 9)
            {
                EnemyDamageAmount = EnemyDamageAmount *= 1.4f;
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

    public void SaveData(Save data)
    {
        data.playerHp = playerHp;
        data.EnemyHp = enemyHp;
        data.Ulty = Ulty;
    }

    public void LoadData(Save data)
    {
        playerHp = data.playerHp;
        enemyHp = data.EnemyHp;
        Ulty = data.Ulty;
    }
}