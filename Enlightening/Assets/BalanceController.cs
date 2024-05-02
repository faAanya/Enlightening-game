using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BalanceController : MonoBehaviour
{
    public MoneySO money;


    public void IncreaseMoney(float amount) => money.amount += amount;

    public void DecreaseMoney(float amount) => money.amount -= amount;

}
