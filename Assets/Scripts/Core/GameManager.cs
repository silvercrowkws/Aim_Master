using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;

    public Player GunMove
    {
        get
        {
            if (player == null)  // 초기화 전에 player에 접근했을 경우
            {
                OnInitialize();
            }
            return player;
        }
    }

    protected override void OnInitialize()
    {
        base.OnInitialize();
        player = FindAnyObjectByType<Player>();
    }

}