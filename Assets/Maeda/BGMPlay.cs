using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _seClips = default;

    /// <summary>音を鳴らすコンポーネント</summary>
    AudioSource _audio => GetComponent<AudioSource>();

    public void BgmPlay(int Index)
    {
        _audio.PlayOneShot(_seClips[Index]);
    }

    public void BgmStop()
    {
        _audio.Stop();
    }
}
