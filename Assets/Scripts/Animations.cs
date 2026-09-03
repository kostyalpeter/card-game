using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject Player;
    public GameObject Shieldd;
    void Update()
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

        else if (Damaging.Asd)
        {
            StartCoroutine(Wait());
        }
        else if (Damaging.Enemy)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        if (gameObject.GetComponent<Animator>() != null)
        {
            if (Damaging.Asd)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Shoot");
                Damaging.Asd = false;
            }
        }
    }
    public void PlayerAnim()
    {
        if (Player != null && NonAttacks.Shield != true)
        {
            Player.GetComponent<Animator>().SetTrigger("Damage");
            Damaging.Hit = true;
            DoubleClick.Countdown = false;
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