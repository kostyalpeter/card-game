using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    public TMP_Text timerText;
    public static float Timer;
    public int TimerTest;
    public GameObject Shop1;
    public GameObject Game1;
    public RectTransform slime;
    public RectTransform archer;
    public RectTransform knight1;
    public RectTransform knight2;
    public RectTransform knight3;
    public RectTransform king;
    public RectTransform wizard;
    public RectTransform prince;
    public RectTransform orc1;
    public RectTransform orc2;
    public RectTransform orc3;
    public RectTransform vampire1;
    public RectTransform vampire2;
    public RectTransform vampire3;
    public RectTransform archerboss;
    public RectTransform oldguardian;
    public RectTransform skeletonseeker;
    public RectTransform sprout;
    public RectTransform undeadexecutioner;
    public RectTransform slimeEnemy;
    public RectTransform archerEnemy;
    public RectTransform knight1Enemy;
    public RectTransform knight2Enemy;
    public RectTransform knight3Enemy;
    public RectTransform kingEnemy;
    public RectTransform wizardEnemy;
    public RectTransform princeEnemy;
    public RectTransform orc1Enemy;
    public RectTransform orc2Enemy;
    public RectTransform orc3Enemy;
    public RectTransform vampire1Enemy;
    public RectTransform vampire2Enemy;
    public RectTransform vampire3Enemy;
    public RectTransform archerbossEnemy;
    public RectTransform oldguardianEnemy;
    public RectTransform skeletonseekerEnemy;
    public RectTransform sproutEnemy;
    public RectTransform undeadexecutionerEnemy;

    public Slider EnemySlider;
    public Slider PlayerSlider;
    public GameObject cards;
    public static bool canTime;
    Shop shop;
    void Start()
    {
        shop = GetComponent<Shop>();
    }
    void Update()
    {
        if (canTime)
        {
            if (Timer > 0)
            {
                Timer -= UnityEngine.Time.deltaTime;
                timerText.text = Timer.ToString("0");
                if (Damaging.EnemyHp <= 0)
                {
                    Debug.Log("Player won!");
                    StartCoroutine(StartShop());
                    canTime = false;
                    shop.StartShop();
                    Shop.Gold++;
                }
                else if (Damaging.PlayerHp <= 0)
                {
                    Debug.Log("Enemy won!");
                    StartCoroutine(StartShop());
                    canTime = false;
                    shop.StartShop();
                    Shop.Gold++;
                }

            }
            else if (Timer <= 0)
            {
                Timer = 0;
                if (Damaging.EnemyHp < Damaging.PlayerHp)
                {
                    Debug.Log("Player won!");
                    StartCoroutine(StartShop());
                    canTime = false;
                    shop.StartShop();
                    Shop.Gold++;
                }
                if (Damaging.EnemyHp > Damaging.PlayerHp)
                {
                    Debug.Log("Enemy won!");
                    StartCoroutine(StartShop());
                    canTime = false;
                    Shop.Gold++;
                }
                if (Damaging.EnemyHp == Damaging.PlayerHp)
                {
                    Timer += 30;
                    Debug.Log("Overtime!");
                }
            }
        }
    }

    public IEnumerator StartShop()
    {
        yield return new WaitForSeconds(1);
        Shop1.SetActive(true);
        Game1.SetActive(false);
        Damaging.EnemyHp = Damaging.MaxEnemyHp;
        Damaging.PlayerHp = Damaging.MaxPlayerHp;
        EnemySlider.gameObject.SetActive(false);
        PlayerSlider.gameObject.SetActive(false);
        Ending();
        cards.SetActive(false);
    }
    public void Ending()
    {
        if (UseCard.Enemy == 1)
        {
            slime.transform.position = new Vector3(slime.transform.position.x, slime.transform.position.y + 1000, slime.transform.position.z);
            slimeEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 2)
        {
            archer.transform.position = new Vector3(archer.transform.position.x, archer.transform.position.y + 1000, archer.transform.position.z);
            archerEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 3)
        {
            knight1.transform.position = new Vector3(knight1.transform.position.x, knight1.transform.position.y + 1000, knight1.transform.position.z);
            knight1Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 4)
        {
            knight2.transform.position = new Vector3(knight2.transform.position.x, knight2.transform.position.y + 1000, knight2.transform.position.z);
            knight2Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 5)
        {
            knight3.transform.position = new Vector3(knight3.transform.position.x, knight3.transform.position.y + 1000, knight3.transform.position.z);
            knight3Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 6)
        {
            king.transform.position = new Vector3(king.transform.position.x, king.transform.position.y + 1000, king.transform.position.z);
            kingEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 7)
        {
            wizard.transform.position = new Vector3(wizard.transform.position.x, wizard.transform.position.y + 1000, wizard.transform.position.z);
            wizardEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 8)
        {
            prince.transform.position = new Vector3(prince.transform.position.x, prince.transform.position.y + 1000, prince.transform.position.z);
            princeEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 9)
        {
            orc1.transform.position = new Vector3(orc1.transform.position.x, orc1.transform.position.y + 1000, orc1.transform.position.z);
            orc1Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 10)
        {
            orc2.transform.position = new Vector3(orc2.transform.position.x, orc2.transform.position.y + 1000, orc2.transform.position.z);
            orc2Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 11)
        {
            orc3.transform.position = new Vector3(orc3.transform.position.x, orc3.transform.position.y + 1000, orc3.transform.position.z);
            orc3Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 12)
        {
            vampire1.transform.position = new Vector3(vampire1.transform.position.x, vampire1.transform.position.y + 1000, vampire1.transform.position.z);
            vampire1Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 13)
        {
            vampire2.transform.position = new Vector3(vampire2.transform.position.x, vampire2.transform.position.y + 1000, vampire2.transform.position.z);
            vampire2Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 14)
        {
            vampire3.transform.position = new Vector3(vampire3.transform.position.x, vampire3.transform.position.y + 1000, vampire3.transform.position.z);
            vampire3Enemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 15)
        {
            archerboss.transform.position = new Vector3(archerboss.transform.position.x, archerboss.transform.position.y + 1000, archerboss.transform.position.z);
            archerbossEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 16)
        {
            oldguardian.transform.position = new Vector3(oldguardian.transform.position.x, oldguardian.transform.position.y + 1000, oldguardian.transform.position.z);
            oldguardianEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 17)
        {
            skeletonseeker.transform.position = new Vector3(skeletonseeker.transform.position.x, skeletonseeker.transform.position.y + 1000, skeletonseeker.transform.position.z);
            skeletonseekerEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 18)
        {
            sprout.transform.position = new Vector3(sprout.transform.position.x, sprout.transform.position.y + 1000, sprout.transform.position.z);
            sproutEnemy.gameObject.SetActive(false);
        }
        if (UseCard.Enemy == 19)
        {
            undeadexecutioner.transform.position = new Vector3(undeadexecutioner.transform.position.x, undeadexecutioner.transform.position.y + 1000, undeadexecutioner.transform.position.z);
            undeadexecutionerEnemy.gameObject.SetActive(false);
        }
    }

    public void Timing()
    {
        canTime = !canTime;
    }
}