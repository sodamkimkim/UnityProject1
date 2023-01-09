using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    // destroy callback
    public delegate void DestroyCallback();
    private DestroyCallback destroyCallback = null;
     
    protected string targetName = null;
    protected float damagePower = 0f;
    protected float hp = 30f;

    public string TargetName
    {
        get { return targetName; }
    }
    public float DamagePower
    {
        get { return damagePower; }
    }
    public float Hp
    {
        get { return hp; }
    }
    public virtual void Attack()
    {
        Debug.Log(targetName + " attacks you!");
    }
    public virtual void Damaged(float _attackPower)
    {
        hp -= _attackPower;
        Debug.Log(targetName + " is Damaged, hp remain + " + "hp");

    }
    public virtual void Die()
    {
        Debug.Log(targetName + " is Die!!");
        Destroy(gameObject);
    }

} // end of class
