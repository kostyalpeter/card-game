using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider slider;
    public RectTransform Panel;
    public float pos;
    public float length;

    void Start()
    {
        pos = Panel.anchoredPosition.x;
    }

    void Update()
    {
        Panel.anchoredPosition = new Vector3(pos - slider.value * length, Panel.anchoredPosition.y, Panel.transform.position.z);
    }
}
