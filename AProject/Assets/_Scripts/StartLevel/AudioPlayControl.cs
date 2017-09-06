/*
 * 
 *      Title:场景UI音频管理类
 * 
 *      Description:
 * 
 *      Date:
 * 
 *      Version:
 * 
 *      Modify Recoder:
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    
    public void PlayButtonEffect() {
        AudioManager.PlayEffect("AudioEffect_ConvertGUIPage");
    }

    static public void StatucPlayButtonEffect() {// static 方法ui执行不了 回头研究
        AudioManager.PlayEffect("AudioEffect_ConvertGUIPage");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
