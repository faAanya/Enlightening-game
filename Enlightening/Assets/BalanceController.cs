using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BalanceController : MonoBehaviour
{
    public MoneySO money;

    public static Action<float> OnIncreaseMoney;
    public static Action<float> OnDecreaseMoney;

    void OnEnable()
    {
        OnIncreaseMoney += IncreaseMoney;
        OnDecreaseMoney += DecreaseMoney;
    }
    void OnDisable()
    {
        OnIncreaseMoney -= IncreaseMoney;
        OnDecreaseMoney -= DecreaseMoney;
    }

    public void IncreaseMoney(float amount) => money.amount += amount;

    public void DecreaseMoney(float amount) => money.amount -= amount;

}
