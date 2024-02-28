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

    // Input System의 "LClick" 액션
    private InputAction lClickAction;    

    // 최근에 맞은 Target을 저장할 변수
    private Target lastHitTarget;

    void Start()
    {
        // Animator 컴포넌트 가져오기
        gunAnimator = GetComponent<Animator>();

        // "LClick" 액션에 대한 참조 얻기
        lClickAction = new InputAction("LClick", binding: "<Mouse>/leftButton");
        lClickAction.Enable();

    }

    void Update()
    {
        // LClick 액션 감지
        if (lClickAction.triggered)
        {
            // GunFire 코루틴 시작
            StartCoroutine(GunFire());
            ShootRay();
        }

    }   

    IEnumerator GunFire()
    {
        // "GunMove" 트리거를 발동하여 애니메이션 전환
        gunAnimator.SetTrigger("GunLClick");
        yield return null;
    }

    void ShootRay()
    {
        // 현재 활성화된 카메라 가져오기
        Camera currentCamera = Camera.main;

        if (currentCamera != null)
        {
            // Ray를 생성하여 마우스 위치에서 화면을 향해 쏜다
            Ray ray = currentCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Ray가 어떤 콜라이더에 부딪히는지 확인
            if (Physics.Raycast(ray, out hit))
            {
                // 부딪힌 콜라이더가 Target인지 Gold인지 확인
                Target target = hit.collider.GetComponent<Target>();
                Gold gold = hit.collider.GetComponent<Gold>();

                if (target != null)
                {
                    // Action 델리게이트 호출
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
            Debug.LogError("왜 또 안되냐?");
        }
        
    }


}
