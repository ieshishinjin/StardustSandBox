/*
 * 本文件用来实现走动功能
 * FirstEdit:2025/7/30
 * LastEdit:2025/8/1
 * Editor:ieshishinjin,zhaoming12345
 * Grade:MI
*/

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class move : MonoBehaviour
{
    // 创建 float 类型变量
    public float speed, x, z, y;
    // 创建私密 CharacterController 类型变量
    [SerializeField] private CharacterController palyercontroller;

    // 开始函数
    void Start()
    {
        // 给变量 CharacterController
        palyercontroller = GetComponent<CharacterController>();
    }

    // 更新函数
    void Update()
    {
        // 获取键盘输入
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // 创建 Vector3 类型变量
        Vector3 move;

        // 计算移动方向
        move = transform.right * x + transform.forward * z + transform.up * y;

        // 应用到游戏中
        palyercontroller.Move(move * speed * Time.deltaTime);

        // 加速
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15;
        }
        else 
        {
            speed = 5;
        }

        // 跳跃
        if (Input.GetKey(KeyCode.Space))
        {
            y = 4;
        }
        else
        {
            y = -1;
        }
    }
}
