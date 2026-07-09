using UnityEngine;

public class Damaging : MonoBehaviour
{
    public int DamageAmount;
    public CardPlacement cardPlacement;
    public int EnemyHp;
    public int PlayerHp;
    public int MaxEnemyHp = 100;
    public int MaxPlayerHp = 100;
    public static bool Hurt;
    public int EnemyDamageAmount;
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
    }
    public void PlayerDamage()
    {
        if (EnemyHp > 0)
        {
            PlayerHp -= EnemyDamageAmount;
        }
    }
}