using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

[System.Serializable]
public class Save
{
    public float playerHp;
    public int Gold;
    public float EnemyHp;
    public int PlayerLevel;
    public int Set;
    public float Time;
    public List<string> CardOrder = new List<string>();
    public bool damageBoost;
    public bool watered;
    public bool oiled;
    public bool LessDamaged;
    public bool Shield;
    public bool Ulty;
}