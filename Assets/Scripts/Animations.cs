using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    public GameObject Player;
    public GameObject Shieldd;
    public static bool damage;
    void Update()
    {
        if (Damaging.EnemyHp > 0 && Damaging.PlayerHp > 0)
        {
            if (Anim.CanHit)
            {
                if (gameObject.GetComponent<Animator>() != null)
                {
                    Anim.CanHit = false;
                    gameObject.GetComponent<Animator>().SetTrigger("Damage");
                    damage = true;
                    StartCoroutine(Wait3());
                    NonAttacks.Watered = false;
                    NonAttacks.Oiled = false;
                    NonAttacks.DamageBoosted = false;
                    NonAttacks.LessDamaged = false;
                    if (DoubleClick.CardPlays == 0)
                    {
                        StartCoroutine(Wait());
                    }
                }
            }
        }

        if (Damaging.Asd && DoubleClick.CardPlays == 0)
        {
            StartCoroutine(Wait());
        }
        if (Damaging.Enemy && DoubleClick.CardPlays == 0)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        if (gameObject.GetComponent<Animator>() != null)
        {
            if (Damaging.Asd && DoubleClick.CardPlays == 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Shoot");
                Damaging.Asd = false;
                Damaging.Enemy = false;
            }
        }
    }
    public IEnumerator Wait3()
    {
        yield return new WaitForSeconds(0.5f);
        damage = false;
    }
    public void PlayerAnim()
    {
        if (Player != null && NonAttacks.Shield != true && DoubleClick.CardPlays == 0)
        {
            Player.GetComponent<Animator>().SetTrigger("Damage");
            Damaging.Hit = true;
            DoubleClick.Countdown = false;
            DoubleClick.CardPlays = DoubleClick.Amount;
        }
        else if (NonAttacks.Shield == true)
        {
            gameObject.GetComponent<Audio>().ShieldHitt();
        }
    }
    public void Shield()
    {
        DoubleClick.Countdown = false;
        DoubleClick.CardPlays = DoubleClick.Amount;
        StartCoroutine(Wait2());
        Shieldd.SetActive(false);
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.1f);
        NonAttacks.Shield = false;
    }
}