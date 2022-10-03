using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class MenuFunctions : MonoBehaviour
{
   
    [SerializeField] private RectTransform _gameInterface;
    [SerializeField] private RectTransform _winMenu;
    [SerializeField] private RectTransform _deathMenu;


    private void Start()
    {
        GameEventManager.PlayerDied += ShowDeathMenu;
        GameEventManager.Won += ShowWinMenu;
    }

    private void OnDestroy()
    {
        GameEventManager.PlayerDied -= ShowDeathMenu;
        GameEventManager.Won -= ShowWinMenu;
    }

    public void Restart()
    {
        Change(_gameInterface);
        GameEventManager.OnRestarted();
    }


    private void ShowDeathMenu()
    {
        Change(_deathMenu);
    }

    private void ShowWinMenu()
    {
        Change(_winMenu);
    }

    private void Change(RectTransform menu)
    {
        _gameInterface.gameObject.SetActive(false);
        _winMenu.gameObject.SetActive(false);
        _deathMenu.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
