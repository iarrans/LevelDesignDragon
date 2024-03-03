using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public int coinValue = 1;

    public float rotationSpeed = 30f; // Velocidad de rotación en grados por segundo

    public void AddCoins()
    {
        UIManager.Instance.AddCoins(coinValue);
    }


    void Update()
    {
        // Rotar el objeto continuamente en el eje vertical
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
