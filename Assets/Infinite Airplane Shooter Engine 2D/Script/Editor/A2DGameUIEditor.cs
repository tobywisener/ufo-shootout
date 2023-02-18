using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(A2DGameUI))]

public class A2DGameUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Texture2D m_Logo = (Texture2D)Resources.Load("Img/IconAir", typeof(Texture2D));
        GUILayout.Label(m_Logo);
        GUILayout.BeginVertical("GroupBox");
        GUILayout.Space(10f);

        GUILayout.Label("This Script is Controlled by Infinity Runner Engine.\nTo Edit Go to Unity Menu:\nDenvzla Estudio/Infinite Airplane Shooter Engine/ 2D Airplane Engine Editor", EditorStyles.boldLabel);

        GUILayout.Space(10f);

        GUILayout.EndVertical();


    }
}
