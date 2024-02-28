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

/// ���� ����Ű�� �������� �Ѱ� ȭ���� ���ư����� �Ѵٰ� ��
/// ��..GoldSpawner���� �����ʿ����� �����Ǵ°� �ƴ϶� ���ʿ����� �����ǰ� �ұ�?
