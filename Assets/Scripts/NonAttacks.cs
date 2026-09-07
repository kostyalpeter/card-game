using UnityEngine;

public class NonAttacks : MonoBehaviour
{
    public GameObject Hp1;
    public GameObject Hp2;
    public Damaging damaging;
    public static bool Shield;
    public static bool Watered;
    public static bool Oiled;
    public static bool DamageBoosted;
    public static bool LessDamaged;

    public void Hp()
    {
        if (Hp1 && Hp2 != null)
        {

            Damaging.EnemyHp /= 2;
            Damaging.PlayerHp /= 2;
            Hp1.SetActive(true);
            Hp2.SetActive(true);
            Hp1.GetComponent<Animator>().SetTrigger("Trigger");
            Hp2.GetComponent<Animator>().SetTrigger("Trigger");
            gameObject.SetActive(false);
        }
    }
    public void DamageBoost()
    {
        DamageBoosted = true;
    }
    public void Heal()
    {

        Damaging.PlayerHp += 20;
    }
    public void MoreGold()
    {

        Shop.Gold += 5;
    }
    public void MoreXP()
    {

        Debug.Log("MoreXP");
    }
    public void LessDamage()
    {
        LessDamaged = true;
    }
    public void MoreTime()
    {
        damaging.NonAttack();

        Time.Timer += 30;
    }
    public void Hide()
    {
        damaging.NonAttack();

        gameObject.SetActive(false);
    }
    public void Shieldd()
    {
        damaging.NonAttack();

        Shield = true;
    }
    public void Water()
    {
        damaging.NonAttack();

        Watered = true;
    }
    public void Oil()
    {
        damaging.NonAttack();

        Oiled = true;
    }
}