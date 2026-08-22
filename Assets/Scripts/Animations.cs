using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject Player;
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
    void PlayerAnim()
    {
        if (Player != null)
        {
            Player.GetComponent<Animator>().SetTrigger("Damage");
            Damaging.Hit = true;
            DoubleClick.Countdown = false;
        }
    }
}