using System;
using ObjectManager1;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    // FPS 표시
    [SerializeField] private int size = 25;
    [SerializeField] private Color color = Color.red;
    private float deltaTime = 0f;

    private void Update()
    {
        // 프레임 간의 시간 차이를 누적하여 부드러운 평균값을 구함 (0.1f는 보간 속도)
        // FPS 표시를 위한 로직
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(30, 30, Screen.width, Screen.height);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = size;
        style.normal.textColor = color;

        float ms = deltaTime * 1000f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.} FPS ({1:0.0} ms)", fps, ms);

        GUI.Label(rect, text, style);
    }

}
