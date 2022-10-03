using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinPicker : MonoBehaviour, IResetable
{
    private List<Coin> _coins = new List<Coin>();

    public void Reset()
    {
        foreach (Coin coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }
        transform.position = Vector3.zero;
        transform.gameObject.SetActive(true);
    }

    private void Start()
    {
        _coins = FindObjectsOfType<MonoBehaviour>().OfType<Coin>().ToList();
        Reset();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coin>())
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject gameObject)
    {
        gameObject.SetActive(false);
        GameEventManager.OnCoinCollected();
        if (!IsCoinLeft()) GameEventManager.OnWon();
    }

    private bool IsCoinLeft()
    {
        foreach (Coin coin in _coins)
        {
            if(coin.gameObject.activeInHierarchy)
                return true;
        }
        return false;
    }
}
