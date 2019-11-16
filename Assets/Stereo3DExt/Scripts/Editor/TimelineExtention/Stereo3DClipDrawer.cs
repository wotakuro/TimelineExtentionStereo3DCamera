using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor.Timeline;
using UnityEditor.Playables;
using UnityEditor;


namespace Stereo3DExt.TimelineExtention
{

    [CustomEditor(typeof(Stereo3DClip))]
    public class Stereo3DClipEditor : Editor
    {

        Rect buttonRect;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var gmo = GameObject.Find("Main Camera");
            if( gmo == null){return;}
            var cam = gmo.GetComponent<Camera>();
            if( cam == null){return;}
            var rt = RenderTexture.GetTemporary(512,256,24);
            var backupRt = cam.targetTexture;
            cam.targetTexture = rt;
            cam.Render();            
            cam.targetTexture = backupRt;


            GUIContent content = new GUIContent(rt);
            EditorGUILayout.LabelField(content,GUILayout.Width(256),GUILayout.Height(128));
            EditorGUILayout.LabelField("FOV;" + cam.fieldOfView);
            RenderTexture.ReleaseTemporary(rt);
        }
        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            base.OnPreviewGUI(r, background);

        }
    }
}
