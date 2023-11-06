using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenegerModify : MonoBehaviour
{
    [Header("coins")]
    [SerializeField] private TMPro.TextMeshProUGUI coinsText;
    [Header("���� ����������")]
    [SerializeField] private Image barAccuracy; //��������
    [SerializeField] private Image barRateOfFare;       //����������������
    [SerializeField] private Image barFareDamage;       //����
    [SerializeField] private TMPro.TextMeshProUGUI costPlayerText;
    [SerializeField] private int costPlayer;

    [SerializeField] GameObject[] Players=new GameObject[0];

    [Header("������������ �������� ��������������")]
    [SerializeField]private float defaultMaxAccuracy;
    [SerializeField] private float defaultMaxRateOfFare;
    [SerializeField] private float defaultMaxFareDamage;

    [SerializeField] DragToRotate DragToRotate;
    [SerializeField] private int coins;
    [SerializeField] Button buyPlayers;
    [SerializeField] Button StartGame;
    [SerializeField] private bool purchasedPlayer;

    public int FreeIndexPlayer;

    [SerializeField] string keyPlayer = "Player";
    [SerializeField] string keyFirstStartGame = "FirstGame";



    void Start()
    {
        
        // ���������, ����� ��������� ���� ����� ������� � ���������� ��.
        for (int characterIndex = 0; characterIndex < Players.Length; characterIndex++)
        {
            if (IsCharacterPurchased(characterIndex))
            {
                ActivateCharacter(characterIndex);
            }
        }
        if (PlayerPrefs.GetInt(keyFirstStartGame, 0) == 1)
        {

        }
        else
        {
            Debug.LogError("addCoins + 2000");
            updateCoinsGame(2000);
            PlayerPrefs.SetInt(keyFirstStartGame, 1);
        }
        GetSpecificalPlayer(1);
        getCoins();
    }

    // ��������, ��� �� �������� ������ �����.
    private bool IsCharacterPurchased(int characterIndex)
    {
        return PlayerPrefs.GetInt(keyPlayer + characterIndex, 0) == 1;
    }

    // ��������� ��������� � ����.
    private void ActivateCharacter(int characterIndex)
    {
        // ��� ��� ��� ��������� ��������� �� �������.
        Players[characterIndex].GetComponent<PlayerShooter>().purchased = true;
        Debug.LogError(Players[characterIndex].name);
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
        //Debug.LogError(accuracy + "  " + rateOffare + "  " + fareDamage+" "+ costPlayer);
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

        //if (costPlayer == 5000000)
        //{
        //    costPlayerText.text = "� ������";
        //}
        if (!TruyBuy)       //����� �� ������ ������
        {
            buyPlayers.interactable = false;
        }
        else {
            buyPlayers.interactable = true;
        }


        if (purchasedPlayer)        //������ ������ ����
        {
            StartGame.interactable = true;
            buyPlayers.interactable = false;
            costPlayerText.text = " ";
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
        PurchaseCharacter(FreeIndexPlayer - 1);
        Debug.LogError("BuyPlayer");
    }

    

    // ������� ��������� � ���������� ���������� � ������� � PlayerPrefs.
    public void PurchaseCharacter(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < Players.Length)
        {
            PlayerPrefs.SetInt(keyPlayer + characterIndex, 1); // 1 - �������� ������
            PlayerPrefs.Save();
            ActivateCharacter(characterIndex);
        }
    }

    public void ResetGame()
    {
        updateCoinsGame(-coins);
        for (int characterIndex = 0; characterIndex < Players.Length; characterIndex++)
        {
            Players[characterIndex].GetComponent<PlayerShooter>().purchased = false;
            PlayerPrefs.SetInt(keyPlayer + characterIndex, 0); // 0 - �������� ������
            PlayerPrefs.Save();
            
        }
        PlayerPrefs.SetInt("KeyLevel", 1);
        print("leve 1");
        PlayerPrefs.Save();
        updateCoinsGame(2000);
    }
}
