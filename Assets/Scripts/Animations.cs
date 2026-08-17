using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (Anim.CanHit)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Damage");
            StartCoroutine(Wait());
            Anim.CanHit = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Animator>().SetTrigger("Shoot");
    }
    void PlayerAnim()
    {
        Player.GetComponent<Animator>().SetTrigger("Damage");
        DoubleClick.Countdown = false;
    }
}