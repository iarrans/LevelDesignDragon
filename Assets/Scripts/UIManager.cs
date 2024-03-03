using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI lifeText;

    public GameObject TextBoxStart;

    public GameObject TextBoxEnd;

    public int coinsNumber;

    public int livesNumber;

    public int maxLife = 7;

    public bool canMove = false;

    private void Awake()
    {
        Instance = this;
        TextBoxStart.SetActive(true);
        TextBoxEnd.SetActive(false);
    }

    public void AddCoins(int quantity)
    {
        coinsNumber+= quantity;
        moneyText.text = "ADN parts: " + coinsNumber.ToString();
    }

    public void ActivatedEndPanel()
    {
        TextBoxEnd?.SetActive(true);
        canMove = false;
    }

    public void SetMoving()
    {
        canMove = true;
    }

    public void ChangeLife(int quantity)
    {
        livesNumber += quantity;
        if (livesNumber >= 7){
            livesNumber = 7;
        }
        else if (livesNumber < 0)
        {
            livesNumber = 0;
        }
        lifeText.text = "Lives: " + livesNumber.ToString();
    }
}
