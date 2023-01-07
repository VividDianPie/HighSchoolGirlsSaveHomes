using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TureCamera : MonoBehaviour
{
   public CinemachineFreeLook vCamera;
    //当前视口缩放
    private float mCurrentViewScale;
    private int ScreenCenterX; 
    private int ScreenCenterY;

    [Header("镜头转动灵敏度")]
    public float rotateAxisSpeed_x = 5f;
    public float rotateAxisSpeed_y = 5f;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);

    [Header("视口缩放配置")]
    public float ScaleSpeed = 10.0f;
    public float ScaleMin = 1.0f;
    public float ScaleMax = 150.0f;

    private bool lockCursor = true;//看向光标

    void Start()
    { 
        ScreenCenterX = Screen.width / 2; 
        ScreenCenterY = Screen.height / 2;
        // 取消虚拟相机的鼠标监听
        vCamera.m_YAxis.m_InputAxisName = "";
        vCamera.m_XAxis.m_InputAxisName = "";

        Cursor.visible = false;

        

        if (Camera.main.orthographic == false)   
        {
            mCurrentViewScale = vCamera.m_Lens.FieldOfView;

        }
        else
        {
            mCurrentViewScale = vCamera.m_Lens.OrthographicSize;

        }
    }
    void Update()
    {
    }


    private void LateUpdate()
    {
        //得到鼠标的移动 移动镜头
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        RotateAxis(-h, -v);
        // 锁定鼠标在中心位置
        if (lockCursor)
        {
            SetCursorPos(ScreenCenterX, ScreenCenterY);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //确定硬件指针是否可见
            Cursor.visible = !Cursor.visible;
            lockCursor = !Cursor.visible;
        }
       
        float s = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(s) > 0) 
        {
            mCurrentViewScale += -s * ScaleSpeed;
            mCurrentViewScale = Mathf.Clamp(mCurrentViewScale, ScaleMin, ScaleMax);
            if (Camera.main.orthographic == true)
            {
                vCamera.m_Lens.OrthographicSize = mCurrentViewScale;
            }
            else
            {
                vCamera.m_Lens.FieldOfView = mCurrentViewScale;
                //Debug.Log(vCamera.m_Lens.FieldOfView);
            }
        }
    }
    public void RotateAxis(float x, float y)
    {
        vCamera.m_XAxis.m_InputAxisValue = x * rotateAxisSpeed_x;
        vCamera.m_YAxis.m_InputAxisValue = y * rotateAxisSpeed_y;
    }
}



