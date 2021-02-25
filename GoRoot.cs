using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GoRoot : EditorWindow
{
    static bool @checked;

    static GameObject activeObj;
    static GameObject parentObj;


    static float ButtonWidth = 75.0f;      // ボタンの大きさ


    [MenuItem("AyahaTools/GoRoot")]

    static void Check()
    {
        var menuPath = "AyahaTools/GoRoot";
        @checked = Menu.GetChecked(menuPath);
        Menu.SetChecked(menuPath, !@checked);

    }

    [InitializeOnLoadMethod]
    static void CreateUI()
    {
        SceneView.duringSceneGui += OnGUI;
    }

    private static void OnGUI(SceneView sceneView)
    {
        // 選択オブジェクトの親オブジェクトを取得
        if (Selection.activeGameObject == true)
        {
            GetObjectParent();
        }

        // ここから描画内容＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
        if (@checked == false)
        {
            Handles.BeginGUI();
            {
                GUILayout.BeginArea(new Rect(0, 0,       // 左上
                    Screen.width / EditorGUIUtility.pixelsPerPoint,     // ウィンドウの横最大
                    Screen.height / EditorGUIUtility.pixelsPerPoint));      // ウィンドウの縦最大
                {
                    GUILayout.BeginVertical();
                    {
                        if(GUILayout.Button("GoRoot", EditorStyles.toolbarButton, GUILayout.Width(ButtonWidth)))
                        {
                            Selection.activeGameObject = parentObj;
                            if (parentObj == null)
                            {
                                Debug.Log("親が無い");
                                return;
                            }

                            //Debug.Log("MoveGoRoot");
                        }
                    }
                    GUILayout.EndVertical();
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }
    }

    // 選択オブジェクトの親オブジェクトを取得
    static void GetObjectParent()
    {
        // 選択しているGameObjectを取得
        activeObj = Selection.activeGameObject;

        // 選択の親オブジェクトまでさかのぼる。
        parentObj = activeObj.transform.root.gameObject;

    }
}
