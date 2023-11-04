using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenegerModify : MonoBehaviour
{
    [Header("coins")]
    [SerializeField] private TMPro.TextMeshProUGUI coinsText;
    [Header("бары статистики")]
    [SerializeField] private Image barAccuracy; //Точность
    [SerializeField] private Image barRateOfFare;       //скорострельность
    [SerializeField] private Image barFareDamage;       //урон
    [SerializeField] private TMPro.TextMeshProUGUI costPlayerText;
    [SerializeField] private int costPlayer;

    [SerializeField] GameObject[] Players=new GameObject[0];

    [Header("максимальные значения характреристик")]
    [SerializeField]private float defaultMaxAccuracy;
    [SerializeField] private float defaultMaxRateOfFare;
    [SerializeField] private float defaultMaxFareDamage;

    [SerializeField] DragToRotate DragToRotate;
    [SerializeField] private int coins;
    [SerializeField] Button buyPlayers;
    [SerializeField] Button StartGame;
    [SerializeField] private bool purchasedPlayer;

    public int FreeIndexPlayer;

    void Start()
    {
        GetSpecificalPlayer(1);
        getCoins();
    }

    private void getCoins()
    {
       coins= PlayerPrefs.GetInt("KeyCoins");
    }
    private int getCpinForPay
    {
        get {
            //return coins;
            if (coins == 0)
            {
                coins=PlayerPrefs.GetInt("KeyCoins");
                return coins;
            }
            return coins;
                
            }
    }
    private void updateCoinsGame(int newCoins)
    {
        coins += newCoins;
        setCoins(coins);
    }
    private void setCoins(int coins)
    {
        PlayerPrefs.SetInt("KeyCoins", coins);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }
    public void GetSpecificalPlayer(int indexPlayer)
    {
        FreeIndexPlayer= indexPlayer;
        PlayerShooter playerShooter = Players[indexPlayer - 1].GetComponent<PlayerShooter>();
        float accuracy = playerShooter.SpeedRotation;
        float rateOffare = playerShooter.defaultShootDelay;
        float fareDamage = playerShooter.damagePerShootable;
        purchasedPlayer = playerShooter.purchased;
        costPlayer = playerShooter.CostPlayer;
        //Debug.LogError(accuracy + "  " + rateOffare+"  "+ fareDamage);
        ShowSpecifical(accuracy, rateOffare, fareDamage,costPlayer);
    }

    private void ShowSpecifical(float Accuracy,float RateOfFare,float FareDamage,int CostPlayer)
    {
        barAccuracy.fillAmount = Accuracy/ defaultMaxAccuracy;
        barRateOfFare.fillAmount= defaultMaxRateOfFare/RateOfFare;
        barFareDamage.fillAmount=FareDamage/ defaultMaxFareDamage;
        costPlayerText.text=CostPlayer.ToString();
        int CoinsGetForPay = getCpinForPay;
        coinsText.text = CoinsGetForPay.ToString();
        bool TruyBuy = checkBuyPlayers;


        if (!TruyBuy)       //можно ли купить игрока
        {
            buyPlayers.interactable = false;
        }
        else {
            buyPlayers.interactable = true;
        }


        if (purchasedPlayer)        //кнопка старта игры
        {
            StartGame.interactable = true;
        }
        else
        {
            StartGame.interactable = false;
        }
    }

    private bool checkBuyPlayers
    {
        get {
            if (costPlayer>coins)
            {
                return false;
            }
            return true;  
                    
            }
    }
    public void BuyPlayer()
    {
        PlayerShooter playerShooter = Players[FreeIndexPlayer-1].GetComponent<PlayerShooter>();
        updateCoinsGame(-playerShooter.CostPlayer);
        playerShooter.purchased = true;
        GetSpecificalPlayer(FreeIndexPlayer);
        Debug.LogError("BuyPlayer");
    }

}
