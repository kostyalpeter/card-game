using UnityEngine;

public class UseCard : MonoBehaviour
{
    public enum Cards { iceshot, swordhit, swordthrow, burst, arrowshot, arrowrain, fireshots, blackarrow, fireball, lightningstrike, firerain, lessdamage, morexp, heal, damageboost, moregold, moretime, shield, hp, none }
    public enum Enemies { slime, archer, knight1, knight2, knight3, king, wizard, prince, orc1, orc2, orc3, vampire1, vampire2, vampire3, archerboss, oldguardian, skeletonseeker, sprout, undeadexecutioner, none }
    public Cards cards;
    public Enemies enemies;
    public static int Enemy;
    GameObject ene;
    GameUI gameui;
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
    void Start()
    {
        gameui = FindAnyObjectByType<GameUI>();
    }


    public void Use()
    {
        if (cards == Cards.iceshot)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.swordhit)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.swordthrow)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.burst)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.arrowshot)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.arrowrain)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.fireshots)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.blackarrow)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.fireball)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.lightningstrike)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.firerain)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.morexp)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.lessdamage)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.heal)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.damageboost)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.moregold)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.moretime)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.shield)
        {
            Debug.Log(cards);
        }

        else if (cards == Cards.hp)
        {
            Debug.Log(cards);
        }
    }

    public void Starting()
    {
        if (Enemy == 1)
        {
            Debug.Log("slime");
            slime.transform.position = gameui.EnemyCardPlace.transform.position;
            slimeEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 2)
        {
            Debug.Log("archer");
            archer.transform.position = gameui.EnemyCardPlace.transform.position;
            archerEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 3)
        {
            Debug.Log("knight1");
            knight1.transform.position = gameui.EnemyCardPlace.transform.position;
            knight1Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 4)
        {
            Debug.Log("kngiht2");
            knight2.transform.position = gameui.EnemyCardPlace.transform.position;
            knight2Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 5)
        {
            Debug.Log("knight3");
            knight3.transform.position = gameui.EnemyCardPlace.transform.position;
            knight3Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 6)
        {
            Debug.Log("king");
            king.transform.position = gameui.EnemyCardPlace.transform.position;
            kingEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 7)
        {
            Debug.Log("wizard");
            wizard.transform.position = gameui.EnemyCardPlace.transform.position;
            wizardEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 8)
        {
            Debug.Log("prince");
            prince.transform.position = gameui.EnemyCardPlace.transform.position;
            princeEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 9)
        {
            Debug.Log("orc1");
            orc1.transform.position = gameui.EnemyCardPlace.transform.position;
            orc1Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 10)
        {
            Debug.Log("orc2");
            orc2.transform.position = gameui.EnemyCardPlace.transform.position;
            orc2Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 11)
        {
            Debug.Log("orc3");
            orc3.transform.position = gameui.EnemyCardPlace.transform.position;
            orc3Enemy.gameObject.SetActive(true);

        }
        if (Enemy == 12)
        {
            Debug.Log("vampire1");
            vampire1.transform.position = gameui.EnemyCardPlace.transform.position;
            vampire1Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 13)
        {
            Debug.Log("vampire2");
            vampire2.transform.position = gameui.EnemyCardPlace.transform.position;
            vampire2Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 14)
        {
            Debug.Log("vampire3");
            vampire3.transform.position = gameui.EnemyCardPlace.transform.position;
            vampire3Enemy.gameObject.SetActive(true);
        }
        if (Enemy == 15)
        {
            Debug.Log("archerboss");
            archerboss.transform.position = gameui.EnemyCardPlace.transform.position;
            archerbossEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 16)
        {
            Debug.Log("oldguardian");
            oldguardian.transform.position = gameui.EnemyCardPlace.transform.position;
            oldguardianEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 17)
        {
            Debug.Log("skeletonseeker");
            skeletonseeker.transform.position = gameui.EnemyCardPlace.transform.position;
            skeletonseekerEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 18)
        {
            Debug.Log("sprout");
            sprout.transform.position = gameui.EnemyCardPlace.transform.position;
            sproutEnemy.gameObject.SetActive(true);
        }
        if (Enemy == 19)
        {
            Debug.Log("undeadexecutioner");
            undeadexecutioner.transform.position = gameui.EnemyCardPlace.transform.position;
            undeadexecutionerEnemy.gameObject.SetActive(true);
        }
    }

    public void One()
    {
        Enemy = 1;
    }
    public void Two()
    {
        Enemy = 2;
    }
    public void Three()
    {
        Enemy = 3;
    }
    public void Four()
    {
        Enemy = 4;
    }
    public void Five()
    {
        Enemy = 5;
    }
    public void Six()
    {
        Enemy = 6;
    }
    public void Seven()
    {
        Enemy = 7;
    }
    public void Eight()
    {
        Enemy = 8;
    }
    public void Nine()
    {
        Enemy = 9;
    }
    public void Ten()
    {
        Enemy = 10;
    }
    public void Eleven()
    {
        Enemy = 11;
    }
    public void Twelve()
    {
        Enemy = 12;
    }
    public void Thirteen()
    {
        Enemy = 13;
    }
    public void Fourteen()
    {
        Enemy = 14;
    }
    public void Fifteen()
    {
        Enemy = 15;
    }
    public void Sixteen()
    {
        Enemy = 16;
    }
    public void Seventeen()
    {
        Enemy = 17;
    }
    public void Eighteen()
    {
        Enemy = 18;
    }
    public void Nineteen()
    {
        Enemy = 19;
    }
}