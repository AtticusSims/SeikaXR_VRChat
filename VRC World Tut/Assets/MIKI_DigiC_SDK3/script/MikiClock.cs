
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class MikiClock : UdonSharpBehaviour
{
    #region プライベート定義群
    /// <summary>
    /// スクリプト対象のテキスト(現在時間)
    /// </summary>
    [SerializeField] private Text targetTime;
    /// <summary>
    /// スクリプト対象のテキスト現在曜日
    /// </summary>
    [SerializeField] private Text targetDOfW;
    /// <summary>
    /// スクリプト対象のテキスト(現在年月日)
    /// </summary>
    [SerializeField] private Text targetYMD;
    /// <summary>
    /// 現在時間
    /// </summary>
    private DateTime nowTime;
    /// <summary>
    /// 現在曜日
    /// </summary>
    private String nowDofW;
    /// <summary>
    /// 現在年月日
    /// </summary>
    private String nowYMD;

    #endregion

    void Start()
    {
        nowTime = DateTime.Now;

        targetTime.text = nowTime.ToString("HH:mm:ss");
        targetDOfW.text = nowTime.ToString("ddd");
        targetYMD.text = nowTime.ToString("yyyy-MM-dd");
    }

    void Update()
    {
        nowTime = DateTime.Now;
        if (targetTime.text != nowTime.ToString("HH:mm:ss")) targetTime.text = nowTime.ToString("HH:mm:ss");
        if (targetDOfW.text != nowTime.ToString("ddd")) targetDOfW.text = nowTime.ToString("ddd");
        if (targetYMD.text != nowTime.ToString("yyyy-MM-dd")) targetYMD.text = nowTime.ToString("yyyy-MM-dd");
    }
}
