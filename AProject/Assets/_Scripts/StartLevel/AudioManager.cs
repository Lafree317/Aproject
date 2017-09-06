/*
 * 
 *      Title:音频管理器
 * 
 *      Description:减少音频管理工作量
 * 
 *      Date:2017-9-3 10:01:33
 * 
 *      Version:1.0
 * 
 *      Modify Recoder:
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;                                                                  // 泛型集合命名空间
using UnityEngine;                                                                                 // 123
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public AudioClip[] AudioClipArray;                                                             // 音频文件数组
    private static Dictionary<string, AudioClip> _Dic;                                             // 音频文件集合
    private static AudioSource[] AudioSourceArray;
    private static AudioSource _AudioSource_BackgroundMusic;                                       // 背景音乐音频源
    private static AudioSource _AudioSource_AudioEffect;                                           // 音效音频源

    private void Awake() {
        // 音频源集合类德加载处理
        _Dic = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClipItem in AudioClipArray) {
            _Dic.Add(audioClipItem.name, audioClipItem);
        }

        // 得到AudioSource
        AudioSourceArray = this.gameObject.GetComponents<AudioSource>();
        _AudioSource_BackgroundMusic = AudioSourceArray[0];
        _AudioSource_AudioEffect = AudioSourceArray[1];

    }


    // Update is called once per frame
    void Update() {

    }

    // 播放背景音乐
    public static void PlayBackground(AudioClip audioClip) {
        // 不能与当前正在播放的背景音乐重复
        if (_AudioSource_BackgroundMusic.clip == audioClip) {
            return;
        }

        // 得到GlobalManager 传过来的数值音量大小
        _AudioSource_BackgroundMusic.volume = 1F;

        // 播放的
        if (audioClip) {
            _AudioSource_BackgroundMusic.clip = audioClip;                                         // 注入音频文件
            _AudioSource_BackgroundMusic.Play();
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayBackground()] audioClip is Null");
        }
    }

    // 播放背景音乐
    public static void PlayBackground(string audioClipName) {
        if (!string.IsNullOrEmpty(audioClipName)) {
            PlayBackground(_Dic[audioClipName]);
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayBackground()] audioClipName is Null");
        }
    }

    // 播放音效
    public static void PlayEffect(AudioClip audioClip) {

        // 得到GlobalManager 传过来的数值音量大小
        _AudioSource_AudioEffect.volume = 1F;

        // 播放的
        if (audioClip) {
            _AudioSource_AudioEffect.clip = audioClip;                                             // 注入音频文件
            _AudioSource_AudioEffect.Play();
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayEffect()] audioClip is Null");
        }
    }

    // 播放音效
    public static void PlayEffect(string audioClipName) {
        if (!string.IsNullOrEmpty(audioClipName)) {
            PlayEffect(_Dic[audioClipName]);
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayEffect()] audioClipName is Null");
        }
    }


}
