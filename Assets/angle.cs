/*
 * 本文件用来实现转动视角功能
 * FirstEdit:2025/7/30
 * LastEdit:2025/8/1
 * Editor:ieshishinjin,zhaoming12345
 * Grade:MI
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angle : MonoBehaviour
{
    // 创建 float 类型变量
    public float x, y, mousespeed;
    // 创建私密 Transform 类型变量
    [SerializeField] private Transform player;

    // 开始函数
    void Start()
    {
        player = transform;
    }

    // 更新函数
    void Update()
    {
        // 获取鼠标移动值
        x = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;

        // 限制垂直转动角度
        Vector3 currentRotation = player.localEulerAngles;
        float newXRotation = currentRotation.x - y;
        if (newXRotation > 180)
        {
            newXRotation -= 360;
        }
        newXRotation = Mathf.Clamp(newXRotation, -80f, 80f);

        // 应用到游戏中
        player.Rotate(Vector3.up * x);
        player.localEulerAngles = new Vector3(newXRotation, player.localEulerAngles.y, currentRotation.z);
    }
}
