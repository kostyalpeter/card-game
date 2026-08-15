using System.Collections;
using UnityEngine;

public class Animations : MonoBehaviour
{
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
}