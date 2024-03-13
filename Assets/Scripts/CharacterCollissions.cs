using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollissions : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        if (other.CompareTag("Coin"))
        {
            other.transform.GetComponent<CoinBehaviour>().AddCoins();
            UIManager.Instance.ChangeLife(1);
            Debug.Log("Aquí habría sonido moneda");
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Enemy"))
        {
            UIManager.Instance.ChangeLife(-1);
            Debug.Log("Aquí habría sonido daño");
        }
        if (other.CompareTag("Life"))
        {
            UIManager.Instance.ChangeLife(1);
            Debug.Log("Aquí habría sonido daño");
        }
        if (other.CompareTag("End"))
        {
            UIManager.Instance.ActivatedEndPanel();
            Debug.Log("Aquí se activa pantalla de fin");
        }
        if (other.CompareTag("End"))
        {
            UIManager.Instance.ActivatedEndPanel();
            Debug.Log("Aquí se activa pantalla de fin");
        }
        if (other.CompareTag("Deathzone"))
        {
            Debug.Log("Aquí se activa el respawn");
        }
    }
}
