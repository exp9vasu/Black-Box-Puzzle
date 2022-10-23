using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform EndPos, FinalPos;
    public GameObject PaticlFX, Trophy, Instruction;
    public int LevelCount;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //else
        //{
        //    Destroy(this);
        //}

    }

    void Start()
    {
        print(PlayerPrefs.GetInt("LevelIndex"));
        print("SCene Count" + SceneManager.sceneCountInBuildSettings);
        print(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("LevelIndex"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelIndex"));
        }

        Invoke("TurnOffInst", 8);
    }

    // Update is called once per frame
    void Update()
    {
        int temp = PlayerPrefs.GetInt("Level");
        UIManager.instance.LevelCount.text = "LEVEL " + (temp + 1).ToString();

        //print(SceneManager.GetActiveScene().buildIndex + "Level");
    }

    public void TurnOffInst()
    {
        Instruction.SetActive(false);
    }

    public void NextLevel()
    {
        LevelCount = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", LevelCount + 1);

        if (SceneManager.GetActiveScene().buildIndex  >= SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("LevelIndex", SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
}
