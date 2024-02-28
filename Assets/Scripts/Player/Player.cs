using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    private Animator gunAnimator;    

    // Input System�� "LClick" �׼�
    private InputAction lClickAction;    

    // �ֱٿ� ���� Target�� ������ ����
    private Target lastHitTarget;

    void Start()
    {
        // Animator ������Ʈ ��������
        gunAnimator = GetComponent<Animator>();

        // "LClick" �׼ǿ� ���� ���� ���
        lClickAction = new InputAction("LClick", binding: "<Mouse>/leftButton");
        lClickAction.Enable();

    }

    void Update()
    {
        // LClick �׼� ����
        if (lClickAction.triggered)
        {
            // GunFire �ڷ�ƾ ����
            StartCoroutine(GunFire());
            ShootRay();
        }

    }   

    IEnumerator GunFire()
    {
        // "GunMove" Ʈ���Ÿ� �ߵ��Ͽ� �ִϸ��̼� ��ȯ
        gunAnimator.SetTrigger("GunLClick");
        yield return null;
    }

    void ShootRay()
    {
        // ���� Ȱ��ȭ�� ī�޶� ��������
        Camera currentCamera = Camera.main;

        if (currentCamera != null)
        {
            // Ray�� �����Ͽ� ���콺 ��ġ���� ȭ���� ���� ���
            Ray ray = currentCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Ray�� � �ݶ��̴��� �ε������� Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                // �ε��� �ݶ��̴��� Target���� Gold���� Ȯ��
                Target target = hit.collider.GetComponent<Target>();
                Gold gold = hit.collider.GetComponent<Gold>();

                if (target != null)
                {
                    // Action ��������Ʈ ȣ��
                    target.OnHitByPlayerAction?.Invoke();
                    lastHitTarget = target;
                }

                if(gold != null)
                {
                    gold.OnHitByPlayerAction?.Invoke();                    
                }

            }  
            
        }
        else
        {
            Debug.LogError("�� �� �ȵǳ�?");
        }
        
    }


}
