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

    }

    void Start()
    {

        //print(SceneManager.GetActiveScene().buildIndex);

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

        if (SceneManager.GetActiveScene().buildIndex  >= 7)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        LevelCount = PlayerPrefs.GetInt("Level");
        //PlayerPrefs.SetInt("Player", PlayerPrefs.GetInt("Level") + 1);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
}
