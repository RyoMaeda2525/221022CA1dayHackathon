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

    [SerializeField, Tooltip("毎秒体力を減らす割合")]
    float _timeLimit = 60f;

    [SerializeField , Tooltip("Playerがダメージを食らった際に減る体力の割合")]
    float _damage = 20f;

    /// <summary>ゲーム中の体力</summary>
    private float _hitpoint = 100;

    /// <summary>時間経過で体力を減らす際に使用するタイマー</summary>
    private float _timer = 0;

    private Tween _tween;

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
        _hpSlider.value = _startHitPoint;
    }

    private void TimeElapsed() 
    {
        _timer += Time.deltaTime;

        if(_timer > 1.0f) 
        {
            _hitpoint -=  1　/ _timeLimit;
            HpSliderUpdate(_hitpoint , _changeInterval);
            _timer = 0;
        }
    }

    private void HpSliderUpdate(float hitpoint , float changeInterval)
    {
        _tween = DOTween.To(() => _hpSlider.value,
            x => _hpSlider.value = x, hitpoint, _changeInterval)
            .OnComplete(() => GameOverJudge());
    }

    private void GameOverJudge() 
    {
        if (_hpSlider.value <= 0.1f) 
        {
            _gameManager.GameOver();
        }
    }

    /// <summary>攻撃を受けた際に指定した分体力を減らすように調整</summary>
    /// <param name="damageValue">この値分ダメージを受ける。体力の最大値は1</param>
    public void OnDamage(float damageValue) 
    {
        _hitpoint -= _startHitPoint / _damage;
        HpSliderUpdate(_hitpoint , 0.1f);
    }
}
