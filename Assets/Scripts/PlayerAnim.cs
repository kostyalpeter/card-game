using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Damaging damaging;
    public void TurnPlayer()
    {
        var player = gameObject.transform.localScale;
        if (player.x == 1)
        {
            player.x = -1;
        }
        else if (player.x == -1)
        {
            player.x = 1;
        }
        gameObject.transform.localScale = player;
    }

    public void Damage()
    {
        damaging.Damage();
    }

    public void AnimEnd()
    {
        DoubleClick.CoolDown = false;
        Damaging.Asd = true;
    }
}