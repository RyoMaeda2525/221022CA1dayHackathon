using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Tooltip("�C���Q�[���̗̑͌����Ԑ���")]
    private float _startHitPoint = 1;

    [SerializeField , Tooltip("�̗͂̃X���C�_�[�o�[")]
    private Slider _hpSlider;

    [SerializeField, Tooltip("�̗̓o�[�����f����鎞��")]
    float _changeInterval = 1.0f;

    [SerializeField, Tooltip("���b�̗͂����炷�l")]
    float _timeDamage = 0.01f;

    /// <summary>�Q�[�����̗̑�</summary>
    private float _hitpoint = 100;

    /// <summary>���Ԍo�߂ő̗͂����炷�ۂɎg�p����^�C�}�[</summary>
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
            .OnComplete(()=>Debug.Log("����"));
    }
}