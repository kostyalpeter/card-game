using UnityEngine;
using System.Collections;

public class DoubleClick : MonoBehaviour
{
    int Clicks = 2;
    public float speed = 0.3f;
    void Update()
    {
        if (Clicks == 0)
        {
            Clicks = 2;
            Debug.Log("Click");
            gameObject.SetActive(false);
        }
    }

    public void Click()
    {
        Clicks -= 1;
        StartCoroutine(ResetClicks());
    }

    IEnumerator ResetClicks()
    {
        yield return new WaitForSeconds(speed);
        Clicks = 2;
    }
}
