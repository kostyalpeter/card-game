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
                gameObject.GetComponent<Animator>().SetTrigger("Damage");
                StartCoroutine(Wait());
                Anim.CanHit = false;
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        if (gameObject.GetComponent<Animator>() != null)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Shoot");
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