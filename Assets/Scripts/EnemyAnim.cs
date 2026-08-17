// using UnityEngine;
// using System.Collections;


// public class EnemyAnim : MonoBehaviour
// {
//     public static bool EnemyAnimBool;
//     public GameObject Player;
//     void Update()
//     {
//         if (EnemyAnimBool)
//         {
//             StartCoroutine(Anim());
//         }
//     }

//     IEnumerator Anim()
//     {
//         yield return new WaitForSeconds(3f);
//         Animation();
//     }

//     public void Animation()
//     {
//         if (EnemyAnimBool)
//         {
//             gameObject.GetComponent<Animator>().SetTrigger("Shoot");
//             EnemyAnimBool = false;
//         }
//     }

//     public void PlayerAnim()
//     {
//         Player.GetComponent<Animator>().SetTrigger("Damage");
//         DoubleClick.Countdown = false;
//     }
// }