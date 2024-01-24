using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int numberOfCoins;

    public TMP_Text countCoin;

    private void Start()
    {
        numberOfCoins = Progress.Instance.coins;
        countCoin.text = numberOfCoins.ToString();
    }

    public void AddOne() 
    {
        numberOfCoins++;
        countCoin.text = numberOfCoins.ToString();
    }

    public void SaveToProgress() 
    {
        Progress.Instance.coins = numberOfCoins;
    }

    public void SpendMoney(int value) 
    {
        numberOfCoins -= value;
        countCoin.text = numberOfCoins.ToString();
    }
}
