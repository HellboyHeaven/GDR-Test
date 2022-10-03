using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour, IResetable
{
    private int _count = 0;
    private TextMeshProUGUI _title;

    public void Reset()
    {
        _count = 0;
        _title.text = _count.ToString();
    }

    private void Start()
    {
        _title = GetComponent<TextMeshProUGUI>();
        GameEventManager.CoinCollected += Show;    
    }

    private void OnDestroy()
    {
        GameEventManager.CoinCollected -= Show;
    }

    private void Show()
    {
        _count++;
        _title.text = _count.ToString();
    }

    
}
