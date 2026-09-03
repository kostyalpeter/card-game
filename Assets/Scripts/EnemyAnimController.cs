using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public void Off()
    {
        gameObject.GetComponent<Animations>().PlayerAnim();
        gameObject.SetActive(false);
    }
}
