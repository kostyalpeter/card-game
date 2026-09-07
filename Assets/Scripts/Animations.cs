using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject Player;
    public GameObject Shieldd;
    void Update()
    {
        if (Damaging.EnemyHp > 0 && Damaging.PlayerHp > 0 && DoubleClick.CardPlays ==0)
        {
            if (Anim.CanHit)
            {
                if (gameObject.GetComponent<Animator>() != null)
                {
                    Anim.CanHit = false;
                    gameObject.GetComponent<Animator>().SetTrigger("Damage");
                    StartCoroutine(Wait());
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
    public void PlayerAnim()
    {
        if (Player != null && NonAttacks.Shield != true && DoubleClick.CardPlays == 0)
        {
            Player.GetComponent<Animator>().SetTrigger("Damage");
            Damaging.Hit = true;
            DoubleClick.Countdown = false;
            DoubleClick.CardPlays = DoubleClick.Amount;
        }
    }
    public void Shield()
    {
        DoubleClick.Countdown = false;
        Shieldd.SetActive(false);
        StartCoroutine(Wait2());
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1f);
        NonAttacks.Shield = false;
    }
}