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

    public GameObject ContinueButton;
    public GameObject FinishButton;
    public TextMeshProUGUI endingText;

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
        moneyText.text = "DNA parts: " + coinsNumber.ToString() + "/50";
    }

    public void ActivatedEndPanel()
    {
        TextBoxEnd.SetActive(true);
        if (coinsNumber >= 50)
        {
            FinishButton.SetActive(true);
            endingText.text = "Great job! We havenow enough samples to test this dna properly. Do you want to keep exploring or should we move to the next task, Ms Devcon?";
        }
        else
        {
            endingText.text = "We need, at least, 50 dna samples to do our tests efficiently. Please, look for more dna. You will be properly rewarded";
        }
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
