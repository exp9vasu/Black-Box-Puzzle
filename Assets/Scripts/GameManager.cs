using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform EndPos, FinalPos;
    public GameObject PaticlFX, Trophy, Instruction;

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
        Invoke("TurnOffInst", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffInst()
    {
        Instruction.SetActive(false);
    }
}
