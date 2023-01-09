using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Zombie1 : Target_Zombie
{


    [SerializeField]
    private GameObject explosionPSPrefab = null;

    private void Awake()
    {
        targetName = "zombie1";
        damagePower = 3f;
        hp = 30f;
    }
    public override void Damaged(float _attackPower)
    {
        if(hp<0)
        {
            // ÆÄ±« ÀÌÆåÆ®
            Instantiate(explosionPSPrefab, transform.position, Quaternion.identity);
            //destroyCallback?.Invoke();
        }
        base.Damaged(_attackPower);
    }
    
} // end of class
