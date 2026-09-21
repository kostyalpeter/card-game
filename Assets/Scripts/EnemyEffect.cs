using UnityEngine;
using UnityEngine.UI;

public class EnemyEffect : MonoBehaviour
{
    void Update()
    {
        Image img = gameObject.GetComponent<Image>();

        if (NonAttacks.Watered)
        {
            NonAttacks.Oiled = false;
            img.color = new Color32(45, 173, 255, 255);
        }
        else if (NonAttacks.Oiled)
        {
            NonAttacks.Watered = false;
            img.color = new Color32(97, 93, 93, 255);
        }
        else if (Animations.damage)
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            img.color = Color.white;
        }
        if (Damaging.Ulty)
        {
            img.color = new Color32(255, 255, 0, 255);
        }
    }
}