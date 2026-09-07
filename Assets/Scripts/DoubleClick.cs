using UnityEngine;
using TMPro;

public class DoubleClick : MonoBehaviour
{
    public float speed = 0.3f;
    CardPlacement cards;
    int currentCardIndex;
    UseCard useCard;
    public GameObject Player;
    public static bool Countdown;
    public Damaging damaging;
    public enum Cards { Shoot, Walk, NonAttack };
    public Cards cardType;
    public TMP_Text Text;
    public Damaging damage;
    public bool selected;
    public RectTransform place;
    public enum SpellType
    {
        None, Ice, Lightning, FireRain, Burst, Sword, FireBall,
        TheBlackArrow, FireShots, ArrowRain, ArrowShot, Heal,
        MoreGold, DamageBoost, LessDamage, MoreXp, Shield, MoreTime, Hp, Water, Oil
    }
    public GameObject CardObject;
    public SpellType spellAnimation;
    InvCardAnim invCardAnim;
    public static int CardPlays = 3;
    public static int Amount = 3;
    void Start()
    {
        cards = FindAnyObjectByType<CardPlacement>();
        if (cards == null)
        {
            Debug.LogError("Error");
        }
        useCard = GetComponent<UseCard>();

    }
    void Update()
    {
        if (Countdown)
        {
            Text.text = "True";
        }
        else
        {
            Text.text = "False";
        }
    }

    public void Click()
    {
        if (selected)
        {
            PlayCard();
        }
        else
        {
            SelectCard();
        }
    }

    void SelectCard()
    {
        DoubleClick[] allCards = CardObject.GetComponentsInChildren<DoubleClick>();
        foreach (DoubleClick card in allCards)
        {
            card.selected = false;
            if (card.invCardAnim != null)
            {
                card.invCardAnim.SetSelected(false);
            }
        }

        selected = true;
        if (invCardAnim != null)
        {
            invCardAnim.SetSelected(true);
        }
    }

    void PlayCard()
    {
        if (selected && Countdown == false && CardPlays > 0)
        {
            CardPlays--;
            if (CardPlays == 0)
            {
                Countdown = true;
            }
            TiggerCardAnimation();
            Debug.Log("Click");
            useCard.DamageAmountSet();
            gameObject.GetComponent<UseCard>().Use();
            gameObject.GetComponent<CardUpgrade>().CardUpgradeCheck();
            if (cardType == Cards.Shoot)
            {
                Player.GetComponent<Animator>().SetTrigger("Shoot");
            }
            else if (cardType == Cards.Walk)
            {
                Player.GetComponent<Animator>().SetTrigger("Walk");
            }
            else if (cardType == Cards.NonAttack)
            {

            }
            var c = gameObject.GetComponent<CardUpgrade>();
            if (c.cardUpgrades == CardUpgrade.CardUpgrades.PurpleGalaxy)
            {

            }
            else if (c.cardUpgrades == CardUpgrade.CardUpgrades.RedGalaxy)
            {
                damage.Damage2();
            }
            else if (c.cardUpgrades == CardUpgrade.CardUpgrades.GreenGalaxy)
            {

            }
            else { }

            RectTransform origin = gameObject.GetComponent<RectTransform>();
            origin.anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            gameObject.GetComponent<RectTransform>().anchoredPosition = place.anchoredPosition;
            Refresh();
        }
    }
    public void Refresh()
    {
        if (gameObject.GetComponent<Card>().CardPlace == 1)
        {
            cards.CardPlace1.GetComponent<Place>().isTaken = false;
        }
        else if (gameObject.GetComponent<Card>().CardPlace == 2)
        {
            cards.CardPlace2.GetComponent<Place>().isTaken = false;
        }
        else if (gameObject.GetComponent<Card>().CardPlace == 3)
        {
            cards.CardPlace3.GetComponent<Place>().isTaken = false;
        }
        cards.RefreshBoard();
    }

    void TiggerCardAnimation()
    {
        Animations2 anim = FindAnyObjectByType<Animations2>();
        if (anim == null) return;

        switch (spellAnimation)
        {
            case SpellType.Ice: anim.Ice(); break;
            case SpellType.Lightning: anim.Lightning(); break;
            case SpellType.FireRain: anim.FireRain(); break;
            case SpellType.Burst: anim.Burst(); break;
            case SpellType.Sword: anim.Sword(); break;
            case SpellType.FireBall: anim.FireBall(); break;
            case SpellType.TheBlackArrow: anim.TheBlackArrow(); break;
            case SpellType.FireShots: anim.FireShots(); break;
            case SpellType.ArrowRain: anim.ArrowRain(); break;
            case SpellType.ArrowShot: anim.ArrowShot(); break;
            case SpellType.Heal: anim.Heal(); break;
            case SpellType.MoreGold: anim.MoreGold(); break;
            case SpellType.DamageBoost: anim.DamageBoost(); break;
            case SpellType.LessDamage: anim.LessDamage(); break;
            case SpellType.MoreXp: anim.MoreXp(); break;
            case SpellType.Shield: anim.Shield(); break;
            case SpellType.MoreTime: anim.MoreTime(); break;
            case SpellType.Hp: anim.Hp(); break;
            case SpellType.Water: anim.Water(); break;
            case SpellType.Oil: anim.Oil(); break;
        }
    }
}