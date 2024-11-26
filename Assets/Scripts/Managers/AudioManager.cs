using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;
    [SerializeField] private float SFXMinDistance;

    public bool playBGM;
    public int currentBGM;
    private void Awake()
    {
        if (instance == null)
        {
            // 如果没有实例，将当前对象设置为实例
            instance = this;
            // 阻止实例被销毁
        }
    }
    private void Update()
    {
        if (!playBGM)
            StopALLBGM();
        else if (!bgm[currentBGM].isPlaying)
        {
            PlayBGM(currentBGM);
        }
    }
    public void PlaySFX(int _sfxindex)
    {
        if (_sfxindex >= 0 && _sfxindex < sfx.Length)
            sfx[_sfxindex].Play();
    }
    public void PlaySFX(int _sfxindex,Transform _source)
    {
        if (_sfxindex >= 0 && _sfxindex < sfx.Length)
            sfx[_sfxindex].Play();
        if(_source != null&& Vector2.Distance(_source.position, _source.position) > SFXMinDistance)//第一个参数应该是player position
            return;
    }
    public void StopSFX(int _index)
    {
        sfx[_index].Stop();
    }
    public void PlayRandomBGM()
    {
        int random = Random.Range(0, bgm.Length);
        PlayBGM(random);
    }
    public void PlayBGM(int _index)
    {
        StopALLBGM();
        bgm[_index].Play();
    }
    public void StopALLBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
            bgm[i].Stop();
    }

}
