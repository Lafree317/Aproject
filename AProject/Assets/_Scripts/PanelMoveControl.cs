/*
 * 
 *      Title:声音设置面板移动
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

public class PanelMoveControl : MonoBehaviour {
    public Animator Ani_AudioSettingPanel; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplaySettingPanel() {
        Ani_AudioSettingPanel.SetBool("isDisPlayInfo", true);
    }

    public void HideAuidoSettingPanel() {
        Ani_AudioSettingPanel.SetBool("isDisPlayInfo", false);
    }
}
