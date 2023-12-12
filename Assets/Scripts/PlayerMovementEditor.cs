using Player;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerController))]
public class PlayerMovementEditor : Editor
{
    private SerializedProperty _gravityScaleProp;

    private SerializedProperty _speedProp;

    private SerializedProperty _jumpHeightProp;

    private SerializedProperty _groundLayerProp;
    //Icon
    private void OnEnable()
    {
        _gravityScaleProp = serializedObject.FindProperty("gravity");
        _speedProp = serializedObject.FindProperty("speed");
        _jumpHeightProp = serializedObject.FindProperty("jumpHeight");
        _groundLayerProp = serializedObject.FindProperty("groundMask");
    }
    public override void OnInspectorGUI()
    {
        var playerMovement = (PlayerController)target;
        //DrawDefaultInspector();
        GUILayout.Space(10);
        GUILayout.Label("Player Inspector Elements", EditorStyles.boldLabel);
        serializedObject.Update();
        EditorGUILayout.PropertyField(_groundLayerProp, new GUIContent("Ground Layer", GetIcon("sv_icon_dot10_sml"), "Lớp có thể va chạm"));
        EditorGUILayout.PropertyField(_speedProp, new GUIContent("Speed", GetIcon("sv_icon_dot11_sml"),"Tốc độ của người chơi"));
        EditorGUILayout.PropertyField(_jumpHeightProp,new GUIContent("Jump Height", GetIcon("sv_icon_dot12_sml"),"Độ cao nhảy của người chơi"));
        EditorGUILayout.PropertyField(_gravityScaleProp, new GUIContent("Gravity",GetIcon("sv_icon_dot13_sml"),"Thay đổi trọng lực của người chơi tương tác với môi trường"));
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Reset Parameters", GUILayout.ExpandWidth(true)))
            ResetParameters();
    }
    private void ResetParameters()
    {
        _groundLayerProp.intValue = LayerMask.GetMask("Environment");
        _gravityScaleProp.floatValue = -18.36f;
        _speedProp.floatValue = 12.0f;
        _jumpHeightProp.floatValue = 6.0f;
        serializedObject.ApplyModifiedProperties();
    }

    private Texture2D GetIcon(string iconName)
    {
       return EditorGUIUtility.IconContent(iconName).image as Texture2D;
    }
}