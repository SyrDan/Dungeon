using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;

    public Player player;

    public FloatingTextManager floatingTextManager;

    public int coins;

    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {

        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }
    private void Awake()
    {
        //if (GameManager.Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        PlayerPrefs.DeleteAll();

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //SaveState
    /*
     * int preferedSkin (vibora skina)
     * int money (denga)
     * int weaponLevel (urovenOruzhiya)
     * 
     */
    public void SaveState()
    {
        string str = "";

        str += "0" + "|";
        str += coins.ToString() + "|";
        str += "0";

        PlayerPrefs.SetString("SaveState", str);
    }

    public void LoadState(Scene s, LoadSceneMode m)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        coins = int.Parse(data[1]);

    }
}
