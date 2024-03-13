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
            Debug.Log("Aqu� habr�a sonido moneda");
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Enemy"))
        {
            UIManager.Instance.ChangeLife(-1);
            Debug.Log("Aqu� habr�a sonido da�o");
        }
        if (other.CompareTag("Life"))
        {
            UIManager.Instance.ChangeLife(1);
            Debug.Log("Aqu� habr�a sonido da�o");
        }
        if (other.CompareTag("End"))
        {
            UIManager.Instance.ActivatedEndPanel();
            Debug.Log("Aqu� se activa pantalla de fin");
        }
        if (other.CompareTag("End"))
        {
            UIManager.Instance.ActivatedEndPanel();
            Debug.Log("Aqu� se activa pantalla de fin");
        }
        if (other.CompareTag("Deathzone"))
        {
            Debug.Log("Aqu� se activa el respawn");
        }
    }
}
