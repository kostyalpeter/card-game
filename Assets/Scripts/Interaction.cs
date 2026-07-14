using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Play;
    bool canPress;
    bool canPressSettings;
    public RectTransform SettingsPanelObject;
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
    Vector2 SetPanelPos;
    public RectTransform SetObject;
    Vector2 SetPos;
    public RectTransform MoveToPos;
    Vector2 MoveTo;
    Vector2 CardPos;
    public RectTransform Card;
    public bool Starting;
    public bool canMove;
    GameUIStart gameUIStart;

    void Start()
    {
        Scale = gameObject.transform.localScale;
        if (SettingsPanelObject != null)
        {
            SetPanelPos = SettingsPanelObject.anchoredPosition;
        }
        if (SetObject != null)
        {
            SetPos = SetObject.anchoredPosition;
        }
        if (MoveToPos != null)
        {
            MoveTo = MoveToPos.anchoredPosition;
        }
        if (Card != null)
        {
            CardPos = Card.anchoredPosition;
        }
        gameUIStart = GetComponent<GameUIStart>();
    }
    void Update()
    {
        if (canGear && GearObject != null)
        {
            GearObject.transform.rotation = Quaternion.Euler(0, 0, GearObject.transform.rotation.eulerAngles.z - GearRotation * UnityEngine.Time.deltaTime * GearRotationSpeed);
        }
        if (canAnim1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 30 * UnityEngine.Time.deltaTime * Flowingspeed, gameObject.transform.position.z);
        }
        if (canAnim2)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 30 * UnityEngine.Time.deltaTime * Flowingspeed, gameObject.transform.position.z);
        }
        if (canSet && SettingsPanelObject != null)
        {
            SettingsPanelObject.anchoredPosition = Vector2.MoveTowards(SettingsPanelObject.anchoredPosition, SetPos, 30 * UnityEngine.Time.deltaTime * Flowingspeed);
        }
        if (!canSet && SettingsPanelObject != null)
        {
            SettingsPanelObject.anchoredPosition = Vector2.MoveTowards(SettingsPanelObject.anchoredPosition, SetPanelPos, 30 * UnityEngine.Time.deltaTime * Flowingspeed);
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
        Starting = true;
    }

    public void SettingsPanel()
    {
        if (!Drag.beingDragged)
        {
            canPressSettings = !canPressSettings;
            if (!canPressSettings)
            {
                canSet = true;
                canGear = true;
                StartCoroutine(Gear());
            }
            if (canPressSettings)
            {
                canSet = false;
                canGear = true;
                StartCoroutine(Gear());
            }
        }
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

    public void CardUp()
    {
        canMove = !canMove;
        if (canMove && gameObject.GetComponent<RectTransform>().anchoredPosition.y == 2296 && GameUIStart.Set >= gameUIStart.locked)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 50f, gameObject.transform.position.z);
            Debug.Log("Up");
        }
        else if (!canMove && gameObject.GetComponent<RectTransform>().anchoredPosition.y >= 2296 && GameUIStart.Set >= gameUIStart.locked)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y - 50f, gameObject.transform.position.z);
            Debug.Log("Down");
        }
    }
}