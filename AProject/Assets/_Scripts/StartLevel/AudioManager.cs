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
    public AudioClip[] audioClipArray;                                                             // 音频文件数组
    private static Dictionary<string, AudioClip> dic;                                              // 音频文件集合
    private static AudioSource[] audioSourceArray;
    private static AudioSource audioSource_BackgroundMusic;                                        // 背景音乐音频源
    private static AudioSource audioSource_AudioEffect;                                            // 音效音频源
    
    private void Awake() {
        // 音频源集合类德加载处理
        dic = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClipItem in audioClipArray) {
            dic.Add(audioClipItem.name, audioClipItem);
        }

        // 得到AudioSource
        audioSourceArray = this.gameObject.GetComponents<AudioSource>();
        audioSource_BackgroundMusic = audioSourceArray[0];
        audioSource_AudioEffect = audioSourceArray[1];

    }


    // Update is called once per frame
    void Update() {

    }

    // 播放背景音乐
    public static void PlayBackground(AudioClip audioClip) {

        // 得到GlobalManager 传过来的数值音量大小
        audioSource_BackgroundMusic.volume = GlobalManager.backgroundAudioVolume;

        // 不能与当前正在播放的背景音乐重复
        if (audioSource_BackgroundMusic.clip == audioClip) {
            return;
        }

        // 播放的
        if (audioClip) {
            audioSource_BackgroundMusic.clip = audioClip; // 注入音频文件
            audioSource_BackgroundMusic.Play();
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayBackground()] audioClip is Null");
        }
    }

    // 播放背景音乐
    public static void PlayBackground(string audioClipName) {
        if (!string.IsNullOrEmpty(audioClipName)) {
            PlayBackground(dic[audioClipName]);
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayBackground()] audioClipName is Null");
        }
    }

    // 播放音效
    public static void PlayEffect(AudioClip audioClip) {

        // 得到GlobalManager 传过来的数值音量大小
        audioSource_AudioEffect.volume = GlobalManager.effectAudioVolume;

        // 播放的
        if (audioClip) {
            audioSource_AudioEffect.clip = audioClip;   // 注入音频文件
            audioSource_AudioEffect.Play();
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayEffect()] audioClip is Null");
        }
    }

    // 播放音效
    public static void PlayEffect(string audioClipName) {

        if (!string.IsNullOrEmpty(audioClipName)) {
            PlayEffect(dic[audioClipName]);
        } else {
            Debug.LogError("[AudioMAnager.cs/PlayEffect()] audioClipName is Null");
        }

    }

    // 改变背景音乐音量
    public static void ChangeBackgroundVolume(float volume) {
        print(volume);
        if (volume < 0 || volume > 1) {
            Debug.LogError("错误的背景音乐音量");
            return;
        }
        
        // 改变globalmanager中的音量数值
        GlobalManager.backgroundAudioVolume = volume;
        audioSource_BackgroundMusic.volume = GlobalManager.backgroundAudioVolume;

    }

    // 改变音效音量
    public static void ChangeEffectVolume(float volume) {

        if (volume < 0 || volume > 1) {
            Debug.LogError("错误的音效音量");
            return;
        }

        // 改变globalmanager中的音量数值
        GlobalManager.effectAudioVolume = volume;
        audioSource_AudioEffect.volume = GlobalManager.effectAudioVolume;
        
    }

}
