using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenegerCoins : MonoBehaviour
{
    public static MenegerCoins S;
    public int Coin;
    [Header("цена улучшений")]
    [SerializeField]private int defaultCostImpruveDamage = 2000;
    [SerializeField]private int defaultCostImpruveRecharge = 2000;
    [Header("поля улучшений")]
    [SerializeField] private TMP_Text costDamage;
    [SerializeField] private TMP_Text costRecharge;

    [Header("коофециент цены")]
    [SerializeField] private int myltyDamage=1;
    [SerializeField] private int myltyRecharge=1;

    [Header("проверка на возможность покупки")]
    [SerializeField] Button byuRecharge;
    [SerializeField] Button byuDamage;

    [SerializeField] private TMP_Text countCoint;

    [SerializeField] TMPro.TextMeshProUGUI coinsOnStart;
    void Start()
    {
        if(S == null) S = this;
        GetCoinaPrefer();
        UpdateShowCoin();
        UpdateCoinsOnStart(0);
        ShowCostImpruve(1,1);
    }

    public void AddCoins(int CountCoin)
    {
        Coin += CountCoin;
        setCoinsPrefer();
        UpdateShowCoin();
    }
    void Update()
    {
        
    }

    private void GetCoinaPrefer()
    {
        Coin = PlayerPrefs.GetInt("KeyCoins");
    }
    private void setCoinsPrefer()
    {
        PlayerPrefs.SetInt("KeyCoins", Coin);
        PlayerPrefs.Save();
    }
    private void UpdateShowCoin()
    {
        countCoint.text = Coin.ToString();
    }

    public void UpdateCoinsOnStart(int CostCoins)
    {
        Coin -= CostCoins;
        coinsOnStart.text = Coin.ToString();
        setCoinsPrefer();
    }
    private void ShowCostImpruve(int myltyplyRecharge,int myltyplyDamage)
    {
        int CostRechargeImprove = defaultCostImpruveRecharge;
        int CostDamageImprove = defaultCostImpruveDamage;

        CostRechargeImprove *= myltyplyRecharge;
        CostDamageImprove *= myltyplyDamage;

        costRecharge.text = CostRechargeImprove.ToString();
        costDamage.text = CostDamageImprove.ToString();
        chekCoinsForBuy(CostRechargeImprove, CostDamageImprove);
    }
    public void myltiCostImpruve(int indexImpruve)
    {
        
        if(indexImpruve ==1) 
        {
            UpdateCoinsOnStart(defaultCostImpruveRecharge * myltyRecharge);
            myltyRecharge++;    
        }
        if(indexImpruve == 2)
        {
            UpdateCoinsOnStart(defaultCostImpruveDamage * myltyDamage);
            myltyDamage++;   
        }
        ShowCostImpruve(myltyRecharge, myltyDamage);

        
    }

    private void chekCoinsForBuy(int recherge,int damage)
    {
        Debug.LogError("recharge " + recherge + "  дамаг " + damage+ "всего денег "+Coin);

        if(recherge>Coin)byuRecharge.interactable = false;
        if(damage>Coin)byuDamage.interactable=false;
    }
}
