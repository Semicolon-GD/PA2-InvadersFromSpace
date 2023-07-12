using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStats : MonoBehaviour
{
    [Range(1, 5)]
    public int maxHealth;
    [HideInInspector] public int currentHealt;
    [HideInInspector] public int maxLifes=3;
    [HideInInspector] public int currentLifes;

    public float shipSpeed;
    public float fireRate;

}
