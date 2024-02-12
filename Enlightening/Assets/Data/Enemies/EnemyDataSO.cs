using UnityEngine;


[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Data/Player Data/EnemySO's")]

public class EnemyDataSO : ScriptableObject
{
    public float damage;
    public float health;
    public float coolDown;
    public float range;
}
