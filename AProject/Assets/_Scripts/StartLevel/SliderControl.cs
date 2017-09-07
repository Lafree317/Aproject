/*
 * 
 *      Title:滑动面板移动控制
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
using UnityEngine.EventSystems;
using System;

public class SliderControl : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    private float _FloStartPositionX; // 鼠标开始的偏移量
    private float _FloPosX;  // 鼠标移动的偏移量
    private float _FloSliderSpeed = 1000;
    private float _FloSmooth = 3F;
    private ScrollRect scrollRect;
    private bool isDrag = false;
	// Use this for initialization
	void Start () {
        AudioManager.PlayBackground("GamePlaying_BackgroundAudio");
	}

    // Update is called once per frame
    void Update () {
        // 滑动脚本完善 添加边界
        
        LerpBegin();


    }
    private void LerpBegin() {

        float lerpX = CaculateLerpX(this.transform.localPosition.x);

        if (isDrag == false) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(lerpX, 0, 0), Time.deltaTime * _FloSmooth);
        }

    }

    // 计算当前要
    private float CaculateLerpX(float scrollX) {

        float lerpX = 0.0f;// 记录计算结果
        float allX = 0.0f;// 记录计算出来总的X
        int childCount = this.transform.childCount;

        for (int i = 0; i < childCount; i++) {

            RectTransform tf = this.transform.GetComponent<RectTransform>();
            float width = tf.rect.size.x;
            allX += width;
           
            if(-scrollX < allX) {// 如果滑动到这一页内
                if(-scrollX > (allX - width / 2) && (i != childCount-1)) {// 如果滑动到这页右半部分 就是下一页  最后一页没有下一页
                    lerpX = allX;
                } else {// 左半部分 上一页
                    lerpX = allX - width;
                }
                return -lerpX;
            }

        }

        Debug.LogError("错误的滑动范围");
        return lerpX;

    }
    



    public void OnBeginDrag(PointerEventData eventData) {
        _FloStartPositionX = eventData.position.x;
        isDrag = true;
    }

    // 正在滑动
    public void OnDrag(PointerEventData eventData) {
        
        _FloPosX = eventData.position.x - _FloStartPositionX;
        float changeSpeed = _FloPosX / _FloSliderSpeed;

        // 移动面板
        this.transform.Translate(new Vector3(changeSpeed, 0, 0), Space.World);
        
        
        
        
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDrag = false;
        AudioPlayControl.StatucPlayButtonEffect();


    }
}
