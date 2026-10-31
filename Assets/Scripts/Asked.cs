using UnityEngine;

public class Asked : MonoBehaviour
{
    public GameObject bg;
    public SaveManager SaveManager;
    public GameObject heart1;
    public GameObject heart2;
    public static int lives = 0;
    public GameObject asked;
    
    private void OnApplicationQuit()
    {
        SaveManager.SaveGame();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Bg()
    {
        bg.SetActive(false);
        asked.SetActive(false);
    }
    public void Hearts()
    {
        GameUIStart.Set = 1;
        lives = 2;
    }
    void Update()
    {
        if(lives == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
        }
        else if(lives == 1)
        {
            heart2.SetActive(false);
        }
        else if(lives == 0)
        {
            heart1.SetActive(false);
        }
    }
}
