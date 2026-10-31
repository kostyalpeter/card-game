using Unity.VisualScripting;
using UnityEngine;

public class CardStatsText : MonoBehaviour
{
    public enum CardType
    {
        iceshot,
        swordhit,
        swordthrow,
        burst,
        arrowshot,
        arrowrain,
        fireshots,
        blackarrow,
        fireball,
        lightningstrike,
        firerain,
        lessdamage,
        morexp,
        heal,
        damageboost,
        moregold,
        moretime,
        shield,
        hp,
        water,
        oil,
    }

    public CardType cardType;

    public struct CardData
    {
        public string CardName;
        public string baseDamage;
        public string Damage;
        public string Level;
        public string Difficulty;

        public CardData(string name, string basedmg, string dmg, string lvl, string diff)
        {
            CardName = name;
            baseDamage = basedmg;
            Damage = dmg;
            Level = lvl;
            Difficulty = diff;
        }
    }

    public CardData GetCardData(CardType type)
    {
        CardStats card = GetComponent<CardStats>();
        var lvl = card.CardLevel;
        var dmg = card.CardDamage;
        return type switch
        {
            CardType.iceshot => new CardData(
                "Ice Shot",
                "Base damage: 10",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.swordhit => new CardData(
                "Sword Hit",
                "Base damage: 15",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.swordthrow => new CardData(
                "Sword Throw",
                "Base damage: 15",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.burst => new CardData(
                "Burst",
                "Base damage: 30",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.arrowshot => new CardData(
                "Arrow Shot",
                "Base damage: 20",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.arrowrain => new CardData(
                "Arrow Rain",
                "Base damage: 5",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.fireshots => new CardData(
                "Fire Shots",
                "Base damage: 15",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.blackarrow => new CardData(
                "Black Arrow",
                "Base damage: 100",
                $"Current damage: {dmg:F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.fireball => new CardData(
                "Fireball",
                "Base damage: 50",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.lightningstrike => new CardData(
                "Lightning Strike",
                "Base damage: 40",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.firerain => new CardData(
                "Fire Rain",
                "Base damage: 5",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.lessdamage => new CardData(
                "Less Damage",
                "Base damage: 5",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Hard"
            ),
            CardType.morexp => new CardData(
                "More XP",
                "Base damage: 0",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.heal => new CardData(
                "Heal",
                "Base heal: 0",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.damageboost => new CardData(
                "Damage Boost",
                "Base boost: 0",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.moretime => new CardData(
                "More Time",
                "Base time: 0",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Easy"
            ),
            CardType.shield => new CardData(
                "Shield",
                "--------------",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.hp => new CardData(
                "HP",
                "--------------",
                $"Current damage: health / 2",
                $"Current Card level: {lvl}",
                "Medium"
            ),
            CardType.water => new CardData(
                "Water",
                "--------------",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Hard"
            ),
            CardType.oil => new CardData(
                "Oil",
                "--------------",
                $"Current damage: {dmg + (dmg * (lvl * 0.1f)):F1}",
                $"Current Card level: {lvl}",
                "Hard"
            ),
            _ => new CardData("Unknown Card Type!", "", "", "", ""),
        };
    }

    void Update()
    {
        CardData data = GetCardData(cardType);
        TMPro.TextMeshProUGUI[] alltext = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        foreach (var tmp in alltext)
        {
            if (tmp.name == "Text (TMP)")
            {
                tmp.text = data.CardName;
            }
            else if (tmp.name == "Text (TMP) (1)")
            {
                tmp.text = data.baseDamage;
            }
            else if (tmp.name == "Text (TMP) (2)")
            {
                tmp.text = data.Damage;
            }
            else if (tmp.name == "Text (TMP) (3)")
            {
                tmp.text = data.Level;
            }
            else if (tmp.name == "Text (TMP) (4)")
            {
                tmp.text = data.Difficulty;
            }
        }
    }
}
