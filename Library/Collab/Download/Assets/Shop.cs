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


    public void BuyShipOne()
    {

        if (shipOneBought == false) {

            shipOneButton.gameObject.SetActive(false);

            if (currencyManager.getMoneyAmount() >= 0)
            {
                shipOneBought = true;
                currencyManager.TakeMoney(5);
                Debug.Log(currencyManager.getMoneyAmount());
                fiveButton.gameObject.SetActive(false);
            }
        }

        if (shipOneBought == true){
            shipOneButton.gameObject.SetActive(true);

        }
    }

    public void BuyShipTwo()
    {

        if (shipTwoBought == false)
        {

            shipTwoButton.gameObject.SetActive(false);

            if (currencyManager.getMoneyAmount() >= 0)
            {
                shipTwoBought = true;
                currencyManager.TakeMoney(0);
                Debug.Log(currencyManager.getMoneyAmount());
                tenButton.gameObject.SetActive(false);
            }
        }

        if (shipTwoBought == true)
        {
            shipTwoButton.gameObject.SetActive(true);

            }
        }

}
