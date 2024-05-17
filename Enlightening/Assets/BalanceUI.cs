using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceUI : MonoBehaviour
{
    public TMP_Text monetText;
    public MoneySO money;

    void Update()
    {
        monetText.text = $"Orbs: {Mathf.Round(money.amount)}";
    }
}
