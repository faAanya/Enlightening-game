using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public MoneySO money;

    public float time;
    public float upgradeCounter;


    void Awake()
    {
        upgradeCounter = 0;
        time = 0;
    }


    void Update()
    {
        time += Time.deltaTime % 60;
    }

    public float CountMoney()
    {
        return 1 / time * 10800 + upgradeCounter * 10;
    }

}
