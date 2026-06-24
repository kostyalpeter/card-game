using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{

    string Text1;
    public TMP_InputField Text2;
    void Update()
    {
        Text1 = Text2.text;
        Debug.Log(Text1);
    }
}