using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private List<IResetable> _resetables = new List<IResetable>();

    private void Start()
    {
        _resetables = FindObjectsOfType<MonoBehaviour>().OfType<IResetable>().ToList();
        load();

        GameEventManager.Restarted += load;
    }

    private void OnDestroy()
    {
        GameEventManager.Restarted -= load;
    }


    private void load()
    {
        foreach (IResetable resetable in _resetables)
        {
            resetable.Reset();
        }
    }
}
