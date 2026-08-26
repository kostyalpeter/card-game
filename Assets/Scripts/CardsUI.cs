using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CardsUI : MonoBehaviour
{
    public Slider slider;
    public RectTransform Panel;
    public RectTransform Panel2;
    public int Length;
    public float ScrollSensitivity;
    float pos;

    void Start()
    {
        pos = Panel.anchoredPosition.y;
    }

    void Update()
    {
        if (Mouse.current == null || !Panel2.gameObject.activeSelf) return;

        Panel.anchoredPosition = new Vector3(Panel.anchoredPosition.x, pos + slider.value * Length, Panel.transform.position.z);

        Vector2 scrollValue = Mouse.current.scroll.ReadValue();

        if (scrollValue.y < 0)
        {
            OnScrollDown();
        }
        if (scrollValue.y > 0)
        {
            OnScrollUp();
        }
    }

    void OnScrollDown()
    {
        slider.value += ScrollSensitivity;
    }
    void OnScrollUp()
    {
        slider.value -= ScrollSensitivity;
    }
}