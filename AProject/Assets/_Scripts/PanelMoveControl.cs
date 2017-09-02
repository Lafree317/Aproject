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
using UnityEngine.UI;
using UnityEngine;

public class PanelMoveControl : MonoBehaviour {
    public Animator Ani_AudioSettingPanel;
    public Animator Ani_WaponPanel;
    
    public Animation Ani_Wapon;
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


    public void DisplayWaponPanel() {
        Ani_WaponPanel.SetBool("IsDisplay", true);
        print(Ani_Wapon);
        
        Ani_Wapon.Play("Sm4_Forward");
        Ani_Wapon.PlayQueued("Sm4_Big");






    }

    public void HideWaponPanel() {
        Ani_WaponPanel.SetBool("IsDisplay", false);
        Ani_Wapon.Play("Sm4_Small");
        Ani_Wapon.PlayQueued("Sm4_Behind");
    }
}
