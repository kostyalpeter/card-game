using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Settings")]
    public RectTransform SettingsPos1;
    public RectTransform SettingsObject;

    [Header("Music")]
    public RectTransform MusicPos1;
    public RectTransform MusicObject;

    [Header("Description")]
    public RectTransform DescriptionPos1;
    public RectTransform DescriptionObject;

    [Header("Cards")]
    public RectTransform CardsPos1;
    public RectTransform CardsObject;

    [Header("Panels")]
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public RectTransform Move;
    // Bools
    bool showSet;
    bool showMus;
    bool showDes;
    bool showCard;
    [Header("Speed")]
    public float speed;

    void Update()
    {
        // Settings Movement

        if (showSet)
        {
            SettingsObject.anchoredPosition = Vector2.MoveTowards(SettingsObject.anchoredPosition, Move.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }
        if (!showSet)
        {
            SettingsObject.anchoredPosition = Vector2.MoveTowards(SettingsObject.anchoredPosition, SettingsPos1.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }

        // Music Movement

        if (showMus)
        {
            MusicObject.anchoredPosition = Vector2.MoveTowards(MusicObject.anchoredPosition, Move.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }
        if (!showMus)
        {
            MusicObject.anchoredPosition = Vector2.MoveTowards(MusicObject.anchoredPosition, MusicPos1.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }

        // Description Movement

        if (showDes)
        {
            DescriptionObject.anchoredPosition = Vector2.MoveTowards(DescriptionObject.anchoredPosition, Move.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }
        if (!showDes)
        {
            DescriptionObject.anchoredPosition = Vector2.MoveTowards(DescriptionObject.anchoredPosition, DescriptionPos1.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }

        // Cards Movement

        if (showCard)
        {
            CardsObject.anchoredPosition = Vector2.MoveTowards(CardsObject.anchoredPosition, Move.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }
        if (!showCard)
        {
            CardsObject.anchoredPosition = Vector2.MoveTowards(CardsObject.anchoredPosition, CardsPos1.anchoredPosition, 30 * UnityEngine.Time.deltaTime * speed);
        }
    }

    public void ShowSettings()
    {
        showSet = !showSet;

        if (showSet)
        {
            Panel1.SetActive(true);
            MusicObject.gameObject.SetActive(false);
            DescriptionObject.gameObject.SetActive(false);
            CardsObject.gameObject.SetActive(false);
        }
        if (!showSet)
        {
            Panel1.SetActive(false);
            MusicObject.gameObject.SetActive(true);
            DescriptionObject.gameObject.SetActive(true);
            CardsObject.gameObject.SetActive(true);
        }
    }
    public void ShowMusic()
    {
        showMus = !showMus;

        if (showMus)
        {
            Panel2.SetActive(true);
            SettingsObject.gameObject.SetActive(false);
            DescriptionObject.gameObject.SetActive(false);
            CardsObject.gameObject.SetActive(false);
        }
        if (!showMus)
        {
            Panel2.SetActive(false);
            SettingsObject.gameObject.SetActive(true);
            DescriptionObject.gameObject.SetActive(true);
            CardsObject.gameObject.SetActive(true);
        }
    }
    public void ShowDescription()
    {
        showDes = !showDes;

        if (showDes)
        {
            Panel3.SetActive(true);
            SettingsObject.gameObject.SetActive(false);
            MusicObject.gameObject.SetActive(false);
            CardsObject.gameObject.SetActive(false);
        }
        if (!showDes)
        {
            Panel3.SetActive(false);
            SettingsObject.gameObject.SetActive(true);
            MusicObject.gameObject.SetActive(true);
            CardsObject.gameObject.SetActive(true);
        }
    }
    public void ShowCards()
    {
        showCard = !showCard;

        if (showCard)
        {
            Panel4.SetActive(true);
            SettingsObject.gameObject.SetActive(false);
            MusicObject.gameObject.SetActive(false);
            DescriptionObject.gameObject.SetActive(false);
        }
        if (!showCard)
        {
            Panel4.SetActive(false);
            SettingsObject.gameObject.SetActive(true);
            MusicObject.gameObject.SetActive(true);
            DescriptionObject.gameObject.SetActive(true);
        }
    }
}