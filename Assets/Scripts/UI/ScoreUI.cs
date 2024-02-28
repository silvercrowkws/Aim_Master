using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI text;
    TargetSpawner targetSpawner;
    GoldSpawner goldSpawner;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        targetSpawner = FindObjectOfType<TargetSpawner>();

        if(targetSpawner != null)
        {
            targetSpawner.ScoreUpdated += UpdateScoreText;
        }

        goldSpawner = FindObjectOfType<GoldSpawner>();

        if(goldSpawner != null)
        {
            goldSpawner.GoldScoreUpdated += UpdateScoreText;
        }
    }
    
    public void UpdateScoreText(int obj)
    {
        text.text = $"Score : {(targetSpawner.score)+(goldSpawner.goldscore)}";        
    }
}

/// 총이 가리키는 방향으로 총과 화면이 돌아갔으면 한다고 함
/// 음..GoldSpawner에서 오른쪽에서만 스폰되는게 아니라 왼쪽에서도 스폰되게 할까?
