using UnityEngine;
using System.Collections;


public class EnemyAnim : MonoBehaviour
{
    public GameObject Anim;

    public void Animation()
    {
        Anim.SetActive(true); 
        Anim.GetComponent<Animator>().SetTrigger("Attack");
    }
}