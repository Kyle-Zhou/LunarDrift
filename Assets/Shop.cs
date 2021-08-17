using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public Button fiveButton;
    public Button tenButton;
    public Button shipOneButton;
    public Button shipTwoButton;
    public CurrencyManager currencyManager;
    private static bool shipOneBought = false;
    private static bool shipTwoBought = false;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Ship2") == 1)
        {
            shipOneButton.gameObject.SetActive(true);
            fiveButton.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Ship3") == 1)
        {
            shipTwoButton.gameObject.SetActive(true);
            tenButton.gameObject.SetActive(false);
        }
    }

    public void BuyShipOne()
    {

        if (shipOneBought == false) {

            shipOneButton.gameObject.SetActive(false);

            if (currencyManager.getMoneyAmount() >= -200)
            {
                shipOneBought = true;
                currencyManager.TakeMoney(200);
                Debug.Log(currencyManager.getMoneyAmount());
                fiveButton.gameObject.SetActive(false);
            }
        }

        if (shipOneBought == true){
            shipOneButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Ship2", 1);

        }
    }

    public void BuyShipTwo()
    {

        if (shipTwoBought == false)
        {

            shipTwoButton.gameObject.SetActive(false);

            if (currencyManager.getMoneyAmount() >= -200)
            {
                shipTwoBought = true;
                currencyManager.TakeMoney(400);
                Debug.Log(currencyManager.getMoneyAmount());
                tenButton.gameObject.SetActive(false);
            }
        }

        if (shipTwoBought == true)
        {
            shipTwoButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Ship3", 1);

        }
    }

}
