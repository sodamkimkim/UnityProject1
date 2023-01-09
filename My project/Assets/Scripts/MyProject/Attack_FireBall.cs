using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_FireBall : MonoBehaviour
{
    private float moveSpeed = 10f;
    private const float attackPower = 3f;

    public float GetPower()
    {
        return attackPower;
    }
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("Target"))
        {
            _other.GetComponent<Target>().Damaged(attackPower);

        }
    }
    private void OnDestroy()
    {
        
    }

} // end of class
