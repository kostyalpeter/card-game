using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Play;
    bool canPress;
    bool canPressSettings;
    public GameObject SettingsPanelObject;
    bool canGear;
    public GameObject GearObject;
    public float GearRotation;
    public float GearRotationSpeed;
    public bool canInteract;
    public bool canAnim1;
    public bool canAnim2;
    public float Flowing;
    public float Flowingspeed;
    bool Clicked;
    Vector3 OriginPos;
    Vector3 Scale;
    public bool canSet;
    Vector3 SetPanelPos;
    public float SetTime;
    public GameObject SetObject;
    Vector3 SetPos;

    void Start()
    {
        Scale = gameObject.transform.localScale;
        SetPanelPos = SettingsPanelObject.transform.position;
        SetPos =  SetObject.transform.position;
    }
    void Update()
    {
        if (canGear)
        {
            GearObject.transform.rotation = Quaternion.Euler(0, 0, GearObject.transform.rotation.eulerAngles.z - GearRotation * Time.deltaTime * GearRotationSpeed);
        }
        if (canAnim1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 30 * Time.deltaTime * Flowingspeed, gameObject.transform.position.z);
            Debug.Log("Up");
        }
        if (canAnim2)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 30 * Time.deltaTime * Flowingspeed, gameObject.transform.position.z);
            Debug.Log("Down");
        }
        if (canSet && Vector2.Distance(SettingsPanelObject.transform.position, SetPos) >= 15)
        {
            SettingsPanelObject.transform.position = new Vector3(SettingsPanelObject.transform.position.x + 30f * Time.deltaTime * Flowingspeed, SettingsPanelObject.transform.position.y, SettingsPanelObject.transform.position.z);
            Debug.Log("Up");
        }
        if (Vector2.Distance(SettingsPanelObject.transform.position, SetPanelPos) >= 15)
        {
            if (!canSet)
            {
                SettingsPanelObject.transform.position = new Vector3(SettingsPanelObject.transform.position.x - 30f * Time.deltaTime * Flowingspeed, SettingsPanelObject.transform.position.y, SettingsPanelObject.transform.position.z);
                Debug.Log("Up");
            }
        }
        if (Vector2.Distance(SettingsPanelObject.transform.position, SetPanelPos) <= 15)
        {
            SettingsPanelObject.transform.position = SetPanelPos;
        }
        if (Vector2.Distance(SettingsPanelObject.transform.position, SetPos) <= 15)
        {
            SettingsPanelObject.transform.position = SetPos;
        }
    }
    public void PlayGame()
    {
        if (!Drag.beingDragged)
        {
            if (!canPress)
            {
                Play.SetActive(true);
                StartCoroutine(ResetPlay1());
            }
            if (canPress && Play.activeSelf)
            {
                Play.SetActive(false);
                StartCoroutine(ResetPlay2());
            }
        }
    }

    IEnumerator ResetPlay1()
    {
        yield return new WaitForSeconds(0.1f);
        canPress = true;
    }
    IEnumerator ResetPlay2()
    {
        yield return new WaitForSeconds(0.1f);
        canPress = false;
    }

    public void StartGame()
    {
        Debug.Log("Start");
    }

    public void SettingsPanel()
    {
        if (!Drag.beingDragged)
        {
            if (!canPressSettings)
            {
                canSet = true;
                canGear = true;
                StartCoroutine(ResetSettings1());
                StartCoroutine(Gear());
            }
            if (canPressSettings && SettingsPanelObject.activeSelf)
            {
                canSet = false;
                canGear = true;
                StartCoroutine(ResetSettings2());
                StartCoroutine(Gear());
            }
        }
    }

    IEnumerator ResetSettings1()
    {
        yield return new WaitForSeconds(0.1f);
        canPressSettings = true;
    }
    IEnumerator ResetSettings2()
    {
        yield return new WaitForSeconds(0.1f);
        canPressSettings = false;
    }
    IEnumerator Gear()
    {
        yield return new WaitForSeconds(0.4f);
        canGear = false;
    }

    public void Interact()
    {
        if (!Drag.beingDragged)
        {
            canInteract = !canInteract;

            if (canInteract)
            {
                canAnim1 = false;
                canAnim2 = true;
                StartCoroutine(Anim2());
            }
            if (!canInteract)
            {
                canAnim1 = true;
                canAnim2 = false;
                StartCoroutine(Anim1());
            }
        }
    }

    IEnumerator Anim1()
    {
        yield return new WaitForSeconds(0.3f);
        canAnim1 = false;
    }
    IEnumerator Anim2()
    {
        yield return new WaitForSeconds(0.3f);
        canAnim2 = false;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform.localScale = Scale - new Vector3(0.2f, 0.2f, 0.2f);
        Debug.Log("Press");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform.localScale = Scale;
        Debug.Log("Press");
    }
}