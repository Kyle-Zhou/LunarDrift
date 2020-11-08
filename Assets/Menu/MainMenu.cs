using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text currencyText;
    public CurrencyManager currencyManager;

    public void Update()
    {
        DisplayCurrency();
    }

    ////public void PlayGame()
    ////{
    ////    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    ////}

    public void DisplayCurrency()
    {
        currencyText.text = (currencyManager.getMoneyAmount()).ToString() + " Coins";
    }

}
