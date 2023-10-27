using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenegerCoins : MonoBehaviour
{
    public static MenegerCoins S;
    public int Coin;
    [SerializeField] private TMP_Text _countCoint;
    void Start()
    {
        if(S == null) S = this;
        UpdateShowCoin();
    }

    public void AddCoins(int CountCoin)
    {
        Coin += CountCoin;
        UpdateShowCoin();
    }
    void Update()
    {
        
    }

    private void UpdateShowCoin()
    {
        _countCoint.text = Coin.ToString();
    }
}
