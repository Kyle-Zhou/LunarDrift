using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public CurrencyManager currencyManager;
    public Text currencyText;
    public Text scoreText1;
    public Timer timer;

    public void Start()
    {
        AddNewCurrency();

        scoreText1.text = timer.getMinutes() + ":" + timer.getSeconds();


    }

    public void PlayEndless()
    {
        SceneManager.LoadScene(DifficultyManager.difficulty);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    public void AddNewCurrency()
    {
        int addedAmount = int.Parse(timer.getSeconds()) + (int.Parse(timer.getMinutes()) * 60);
        //int addedAmount = 10;
        currencyManager.AddMoney(addedAmount);

        //displat currency
        currencyText.text = "+" + addedAmount.ToString() + " coins";
    }

}
