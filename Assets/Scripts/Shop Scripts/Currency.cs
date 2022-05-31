using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int currency; //this is the currency amount
    public Text currencyText; //this is for showing the currency onscreen
    public Text gamePlayCurrencyText; //for gameplay viewing

    private void Start()
    {
        currencyText.text = currency.ToString();
        gamePlayCurrencyText.text = "Money: \n" + currency.ToString();
    }

    public int GetCurrency()
    {
        return currency; //returns the current currency
    }

    public void SetCurrency(int inCurrency)
    {
        currency = currency + inCurrency; //adds the currency with the parameter
        currencyText.text = currency.ToString(); //updates the UI
        gamePlayCurrencyText.text = "Money: \n" + currency.ToString();
    }

    public void SubtractCurrency(int inCurrency)
    {
        currency = currency - inCurrency; //subtracts the currency with the parameter
        currencyText.text = currency.ToString(); //updates the UI
        gamePlayCurrencyText.text = "Money: \n" + currency.ToString();
    }

}
