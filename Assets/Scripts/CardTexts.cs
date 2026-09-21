using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardTexts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform Box;
    public TMP_Text Text;
    public static bool ShowBool;
    static Vector3 OffSet;
    static RectTransform clickedCard;
    public float OffSet1 = 315;
    void Update()
    {
        if (Box != null)
        {

            if (ShowBool)
            {

                Box.gameObject.SetActive(true);
                Box.anchoredPosition = OffSet;
            }
            else
            {
                Box.gameObject.SetActive(false);
            }
        }
    }

    public void Show()
    {
        ShowBool = !ShowBool;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickedCard == gameObject.GetComponent<RectTransform>())
        {
            Show();
        }
        else
        {
            ShowBool = true;
            clickedCard = gameObject.GetComponent<RectTransform>();

            var pos = gameObject.GetComponent<RectTransform>().anchoredPosition;

            OffSet = new Vector3(pos.x, pos.y += OffSet1, gameObject.transform.position.z);
        }
    }
}