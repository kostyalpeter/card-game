using UnityEngine;

public class UseCard : MonoBehaviour
{
    public enum Cards { iceshot, swordhit, swordthrow, burst, arrowshot, arrowrain, fireshots, blackarrow, fireball, lightningstrike, firerain, lessdamage, morexp, heal, damageboost, moregold, moretime, shield, hp, none }
    public enum Enemies { slime, archer, knight1, knight2, knight3, king, wizard, prince, orc1, orc2, orc3, vampire1, vampire2, vampire3, archerboss, oldguardian, skeletonseeker, sprout, undeadexecutioner, none }
    public Cards cards;
    public Enemies enemies;
    public static int Enemy;
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
        }
        if (Enemy == 2)
        {
            Debug.Log("archer");
        }
        if (Enemy == 3)
        {
            Debug.Log("knight1");
        }
        if (Enemy == 4)
        {
            Debug.Log("kngiht2");
        }
        if (Enemy == 5)
        {
            Debug.Log("knight3");
        }
        if (Enemy == 6)
        {
            Debug.Log("king");
        }
        if (Enemy == 7)
        {
            Debug.Log("wizard");
        }
        if (Enemy == 8)
        {
            Debug.Log("prince");
        }
        if (Enemy == 9)
        {
            Debug.Log("orc1");
        }
        if (Enemy == 10)
        {
            Debug.Log("orc2");
        }
        if (Enemy == 11)
        {
            Debug.Log("orc3");
        }
        if (Enemy == 12)
        {
            Debug.Log("vampire1");
        }
        if (Enemy == 13)
        {
            Debug.Log("vampire2");
        }
        if (Enemy == 14)
        {
            Debug.Log("vampire3");
        }
        if (Enemy == 15)
        {
            Debug.Log("archerboss");
        }
        if (Enemy == 16)
        {
            Debug.Log("oldguardian");
        }
        if (Enemy == 17)
        {
            Debug.Log("skeletonseeker");
        }
        if (Enemy == 18)
        {
            Debug.Log("sprout");
        }
        if (Enemy == 19)
        {
            Debug.Log("undeadexecutioner");
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