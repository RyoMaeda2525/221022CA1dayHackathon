using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlay : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _seClips = default;

    /// <summary>音を鳴らすコンポーネント</summary>
    AudioSource _audio => GetComponent<AudioSource>();

    public void SePlay(int Index)
    {
        _audio.PlayOneShot(_seClips[Index]);
    }

    public void SeStop() 
    {
        _audio.Stop();
    }
}
