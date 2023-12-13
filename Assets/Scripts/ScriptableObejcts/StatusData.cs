using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "Scriptable Object/StatusData", order = 0)]
[System.Serializable]
public class StatusData : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _currentHp;
    [SerializeField] private float _atk;
    [SerializeField] private float _def;
    [SerializeField] private float _maxExp;
    [SerializeField] private float _currentExp;
    
    public int Level { get => _level; private set { } }
    public float MaxHP { get => _maxHp; private set { } }
    public float CurrentHP { get => _currentHp; private set { } }
    public float Atk { get => _atk; private set { } }
    public float Def { get => _def; private set { } }
    public float MaxExp { get => _maxExp; private set { } }
    public float CurrentExp { get => _currentExp; private set { } }
}