using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private GameObject fxSmokeBoost = null;
    [SerializeField]
    private GameObject fireAttackPrefab = null;
    [SerializeField]
    private Transform attackSpawnPoint = null;
    [SerializeField]
    private Transform smokeSpawnPointTrLeft = null;
    [SerializeField]
    private Transform smokeSpawnPointTrRight = null;

    private CharacterController cc = null;
    private Camera cam = null;
    private float moveSpeed = 2500f;
    private const float moveSpeedCnst = 2500f;
    private float rotSpeed = 40f;

    // cam const 설정 값
    const float cnstCamRotX = 14.755f;
    const float cnstCamRotY = 0f;
    const float cnstCamRotZ = 0f;
    private Vector3 camRot = Vector3.zero;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        camRot = cam.transform.rotation.eulerAngles;
    }
    private void Update()
    {
        MovingProcess();
        RotateProcess();
        LookProcess();
        AttackProcess();
    }

    private void AttackProcess()
    {
        Vector3 attackSpawnPos = attackSpawnPoint.position;
        attackSpawnPos.z = attackSpawnPoint.transform.position.z;
        GameObject go = null;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            go = Instantiate(fireAttackPrefab, attackSpawnPos, Quaternion.identity);
            go.transform.SetParent(attackSpawnPoint);

        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            Destroy(go);
        }
    }

    private void RotateProcess()
    {
        float axisH = Input.GetAxis("Horizontal");
        Vector3 eulerAngle = transform.rotation.eulerAngles;
        eulerAngle.y += rotSpeed * Time.deltaTime * axisH;
        transform.rotation = Quaternion.Euler(eulerAngle);
    } // end of RotateProcess()
    private void MovingProcess()
    {
        //float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        GameObject bostGoL = null;
        GameObject bostGoR = null;
        float doubleKeyInterval = 0.1f;
        float oneKeyUpTime = 0f;
        bool isOneKeyDown = false;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            moveSpeed = moveSpeed * 5f;
            Vector3 smokePosLeft = smokeSpawnPointTrLeft.position;
            Vector3 smokePosRight = smokeSpawnPointTrRight.position;
            smokePosLeft.y = 1f;
            smokePosRight.y = 1f;
            bostGoL = Instantiate(fxSmokeBoost, smokePosLeft, Quaternion.Euler(0f, 90f, 0f));
            bostGoR = Instantiate(fxSmokeBoost, smokePosRight, Quaternion.Euler(0f, 90f, 0f));
            bostGoL.transform.SetParent(smokeSpawnPointTrLeft);
            bostGoR.transform.SetParent(smokeSpawnPointTrRight);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed = moveSpeedCnst;
            Destroy(bostGoL);
            Destroy(bostGoR);
        }
        go();

    } // end of MovingProcess()
    private void go()
    {
        float axisV = Input.GetAxis("Vertical");
        Vector3 camF = cam.transform.forward;
        camF.y = 0f;
        camF.Normalize();
        Vector3 dirF = camF * axisV;
        Vector3 dir = dirF;
        dir.Normalize();
        cc.SimpleMove(dir * moveSpeed * Time.deltaTime);
    }


    private void LookProcess()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        camRot = cam.transform.rotation.eulerAngles;
        camRot.z = cnstCamRotZ;
        camRot.x += -mouseY * rotSpeed * Time.deltaTime;
        camRot.y += mouseX * rotSpeed * Time.deltaTime;
        cam.transform.rotation = Quaternion.Euler(camRot);
        Debug.Log("mouseX : " + mouseX);
        Debug.Log("mouseY : " + mouseY);
        Vector3 tankRt = transform.rotation.eulerAngles;

        // space누르면 카메라 rot초기화
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            cam.transform.rotation = Quaternion.Euler(tankRt.x + cnstCamRotX, tankRt.y + cnstCamRotY, tankRt.z + cnstCamRotZ);
        }

    } // end of LookProcess()

} // end of class
