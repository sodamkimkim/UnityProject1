using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target_Zombie : Target
{
    public override void Attack()
    {
        base.Attack();
    }

    public override void Damaged(float _attackPower)
    {
        base.Damaged(_attackPower);
    }

    public override void Die()
    {
        base.Die();
    }

} // end of class
