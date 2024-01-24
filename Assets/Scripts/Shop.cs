using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    PlayerModifier playerModifier;

    private void Start()
    {
        playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth() 
    {
        if (coinManager.numberOfCoins >= 100) 
        {
            coinManager.SpendMoney(100);
            Progress.Instance.coins = coinManager.numberOfCoins;
            Progress.Instance.width += 100;
            playerModifier.SetWidth(Progress.Instance.width);
        }
    }
    public void BuyHeight() 
    {
        if (coinManager.numberOfCoins >= 100)
        {
            coinManager.SpendMoney(100);
            Progress.Instance.coins = coinManager.numberOfCoins;
            Progress.Instance.height += 100;
            playerModifier.SetHeight(Progress.Instance.height);
        }
    }
}
