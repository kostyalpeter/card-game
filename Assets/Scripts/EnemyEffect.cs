using UnityEngine;
using UnityEngine.UI;

public class EnemyEffect : MonoBehaviour
{
    void Update()
    {
        Image img = gameObject.GetComponent<Image>();

        if (NonAttacks.Watered)
        {
            img.color = new Color32(45, 173, 255, 255);
        }
        if (NonAttacks.Oiled)
        {
            img.color = new Color32(97, 93, 93, 255);
        }
    }
}