using TMPro;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{
    public TMP_Text Text;
    public Slider Slider;

    public int minFps = 30;
    public int maxFps = 1000;

    private int frame = 0;
    private float timer = 0f;
    private int frameCount = 0;
    private int targetFps = 60;
    public GameObject X1;
    public GameObject X2;
    public bool canTime;

    void Start()
    {
        QualitySettings.vSyncCount = 0;

        if (Slider != null)
        {
            Slider.minValue = minFps;
            Slider.maxValue = maxFps;
            Slider.value = targetFps;

            Slider.onValueChanged.AddListener(OnSliderChanged);
        }

        Application.targetFrameRate = targetFps;
    }

    void Update()
    {
        frameCount++;
        timer += UnityEngine.Time.deltaTime;

        if (timer >= 1f)
        {
            frame = Mathf.RoundToInt(frameCount / timer);
            Text.text = frame.ToString();

            frameCount = 0;
            timer = 0f;
        }
    }

    private void OnSliderChanged(float value)
    {
        targetFps = Mathf.RoundToInt(value);
        Application.targetFrameRate = targetFps;
    }

    private void OnDestroy()
    {
        if (Slider != null)
        {
            Slider.onValueChanged.RemoveListener(OnSliderChanged);
        }
    }
    public void Click()
    {
        if (X1.activeSelf)
        {
            X1.SetActive(false);
            X2.SetActive(false);
            canTime = false;
            Text.gameObject.SetActive(false);
        }
        else if (!X1.activeSelf)
        {
            X1.SetActive(true);
            X2.SetActive(true);
            canTime = true;
            Text.gameObject.SetActive(true);
        }
    }
}