using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterCollissions : MonoBehaviour
{
    //Puntos de spawn
    public Transform SpawPosition;

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
            //Se evalúa el punto de respawn más cercano a donde el jugador ha caído (sin contar la altura y)
            Debug.Log("Aquí se respawnea");
            RespawnNearestPosition();
        }
        if (other.CompareTag("Spawn"))
        {
            //Se evalúa el punto de respawn más cercano a donde el jugador ha caído (sin contar la altura y)
            Debug.Log("Aquí se cambia el punto de respawn");
            SpawPosition = other.transform;
        }
    }

    public void RespawnNearestPosition()
    {
        Debug.Log("respawn");
        transform.position = SpawPosition.transform.position;
        UIManager.Instance.ChangeLife(-1);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            // Asigna la plataforma como padre del personaje para que se mueva con ella
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            // Desasigna la plataforma como padre del personaje
            transform.parent = null;
        }
    }
}
