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
        if(instance == null)
        {
            instance = this;
        }
       
    }

    void Start()
    {
        UIManager.instance.LevelCount.text = "LEVEL " + PlayerPrefs.GetInt("Level")+1.ToString();

        Invoke("TurnOffInst", 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffInst()
    {
        Instruction.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        //LevelCount = PlayerPrefs.GetInt("Level");
        //PlayerPrefs.SetInt("Player", PlayerPrefs.GetInt("Level")+1);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
