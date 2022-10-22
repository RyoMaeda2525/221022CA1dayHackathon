using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Tooltip("インゲームの体力兼時間制限")]
    private float _startHitPoint = 1;

    [SerializeField , Tooltip("体力のスライダーバー")]
    private Slider _hpSlider;

    [SerializeField, Tooltip("体力バーが反映される時間")]
    float _changeInterval = 1.0f;

    [SerializeField, Tooltip("毎秒体力を減らす値")]
    float _timeDamage = 0.01f;

    /// <summary>ゲーム中の体力</summary>
    private float _hitpoint = 100;

    /// <summary>時間経過で体力を減らす際に使用するタイマー</summary>
    private float _timer = 0;

    private Tween Tween;

    private void Start()
    {
        HitPointRiset();
    }

    private void FixedUpdate()
    {
        TimeElapsed();
    }

    private void HitPointRiset() 
    {
        _hitpoint = _startHitPoint;
        _hpSlider.maxValue = _startHitPoint;
    }

    private void TimeElapsed() 
    {
        _timer += Time.deltaTime;

        if(_timer > 1.0f) 
        {
            _hitpoint -= _timeDamage;
            HpSliderUpdate(_hitpoint);
            _timer = 0;
        }
    }

    private void HpSliderUpdate(float hitpoint)
    {
        Tween = DOTween.To(() => _hpSlider.value,
            x => _hpSlider.value = x ,hitpoint ,_changeInterval)
            .OnComplete(()=>Debug.Log("完了"));
    }
}
