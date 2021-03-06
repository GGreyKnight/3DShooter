using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject gunPrefab;

    [Header("Stats")]
    public int minDamage;
    public int maxDamage;
    public float maximumRange;
}
