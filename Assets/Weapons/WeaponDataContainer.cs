using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponDataContainer : ScriptableObject
{

    public int[] fireModes;
    public int fireRate;
    public GameObject weaponPrefab;
    public GameObject projectile;
    public float damage;
    public int prioritization;
    public float muzzleVelocity;

}
