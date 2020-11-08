using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    //private static int bankAccount = 0;
    //private static int moneyAmount = bankAccount;
    private static int moneyAmount = 0;

    private void Start()
    {

        //bankAccount = PlayerPrefs.GetInt("currencyPref");
        moneyAmount = PlayerPrefs.GetInt("currencyPref");

    }

    public int getMoneyAmount()
    {
        return moneyAmount;
    }

    public void AddMoney(int amount)
    {
    
        moneyAmount += amount;
        PlayerPrefs.SetInt("currencyPref", moneyAmount);
        //PlayerPrefs.SetInt("currencyPref", bankAccount + amount);
    }

    public void TakeMoney(int amount)
    {
        moneyAmount -= amount;
        PlayerPrefs.SetInt("currencyPref", moneyAmount);
        //PlayerPrefs.SetInt("currencyPref", bankAccount - amount);

    }


}
