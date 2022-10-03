using UnityEngine;

[System.Serializable]
public class Pair<TKey, TValue>
{
    public TKey Key { get => _key; }
    public TValue Value { get => _value; }

    [SerializeField] private TKey _key;
    [SerializeField] private TValue _value;

}
