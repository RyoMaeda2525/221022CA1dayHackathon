using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    GameManager _gameManager;

    [SerializeField, Tooltip("インゲームの体力兼時間制限")]
    private float _startHitPoint = 1;

    [SerializeField , Tooltip("体力のスライダーバー")]
    private Slider _hpSlider;

    [SerializeField, Tooltip("体力バーが反映される時間")]
    float _changeInterval = 1.0f;

    [SerializeField, Tooltip("毎秒体力を減らす値")]
    float _timeLimit = 60f;

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
            _hitpoint -=  1　/ _timeLimit;
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

    /// <summary>攻撃を受けた際に指定した分体力を減らすように調整</summary>
    /// <param name="damageValue">この値分ダメージを受ける。体力の最大値は1</param>
    public void OnDamage(float damageValue) 
    {
        _hitpoint -= damageValue;
    }
}
