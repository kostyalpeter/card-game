using UnityEngine;
using TMPro;

public class Time : MonoBehaviour
{
    public TMP_Text timerText;
    public static float Timer = 180;
    public int TimerTest;
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= UnityEngine.Time.deltaTime;
            timerText.text = Timer.ToString("0");
        }

        if(Timer <= 0)
        {
            Timer = 0;
            if(Damaging.EnemyHp < Damaging.PlayerHp)
            {
                Debug.Log("Player won!");
            }
            if(Damaging.EnemyHp > Damaging.PlayerHp)
            {
                Debug.Log("Enemy won!");
            }
            if(Damaging.EnemyHp == Damaging.PlayerHp)
            {
                Timer += 30;
                Debug.Log("Overtime!");
            }
        }
    }
}