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
    
    public int Level { get => _level; set { _level = value; } }
    public float MaxHP { get => _maxHp; set { _maxHp = value; } }
    public float CurrentHP { get => _currentHp; set { } }
    public float Atk { get => _atk; set { _atk = value; } }
    public float Def { get => _def; set { _def = value; } }
    public float MaxExp { get => _maxExp; set { _maxExp = value; } }
    public float CurrentExp { get => _currentExp; set { _currentExp = value; } }

    public static StatusData operator +(StatusData lhs, StatusData rhs)
    {
        var res = CreateInstance<StatusData>();
        if (lhs != null && rhs != null)
        {
            res._level = lhs._level + rhs._level;
            res._maxHp = lhs._maxHp + rhs._maxHp;
            res._currentHp = lhs._currentHp + rhs._currentHp;
            res._atk = lhs._atk + rhs._atk;
            res._def = lhs._def + rhs._def;
            res._maxExp = lhs._maxExp + rhs._maxExp;
            res._currentExp = lhs._currentExp + rhs._currentExp;
        }
        return res;
    }
}