using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTexts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform Box;
    public TMP_Text Text;
    public static bool ShowBool;
    static Vector3 OffSet;
    void Update()
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

    public void Show()
    {
        ShowBool = !ShowBool;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Show();
        var pos = gameObject.GetComponent<RectTransform>().anchoredPosition;

        OffSet = new Vector3(pos.x, pos.y += 315, gameObject.transform.position.z);
    }
}