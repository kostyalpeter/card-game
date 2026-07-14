using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public bool Countdown2 = true;
    public bool Hurt2 = true;
    public GameObject Player;
    public Damaging damaging;
    public bool Die;
    void Update()
    {
        Debug.Log(DoubleClick.Countdown);
        if (DoubleClick.Countdown && Countdown2 == true)
        {
            StartCoroutine(Wait());
            Countdown2 = false;
        }

        if (Damaging.Hurt && Hurt2 == true)
        {
            Hurt();
            Hurt2 = false;
        }
        if (Damaging.EnemyHp <= 0 && !Die)
        {
            StartCoroutine(Wait3());
        }
    }
    public void EnemyAnim()
    {
        GetComponent<Animator>().SetTrigger("Shoot");
        DoubleClick.Countdown = false;
        Countdown2 = true;
        Debug.Log("Countdown reset");
        StartCoroutine(Wait2());
        damaging.PlayerDamage();
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        EnemyAnim();
    }
    public void Hurt()
    {
        GetComponent<Animator>().SetTrigger("Damage");
        Damaging.Hurt = false;
        Hurt2 = true;
    }
    public IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.4f);
        if (!Die)
        {
            Player.GetComponent<Animator>().SetTrigger("Damage");
        }
    }
    public IEnumerator Wait3()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetTrigger("Die");
        Die = true;
    }

}