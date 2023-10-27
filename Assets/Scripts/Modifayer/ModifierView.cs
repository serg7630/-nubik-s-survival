using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierView : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;
    [SerializeField] private Image recharge;
    [SerializeField] private Image firePower;
    private Image imageWiev;

    public void SetVisuals(bool isPositive, int amount)
    {
        backgroundImage.color = isPositive ? positiveColor : negativeColor;
        string sign = isPositive ? "+ ": "- " ;
        if (amount == 1)
        {
            recharge.enabled = false;
        }
        else
        {
            firePower.enabled = false;
        }
        amountText.text = sign;

    }
}
