using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stereo3DExt
{

    public class StereoCameraController : MonoBehaviour
    {
        private Camera originCamera;
        private Camera[] childrenCamera;

        public float eyeDistance = 0.05f;
        // Start is called before the first frame update
        void Start()
        {
            originCamera = this.GetComponentInParent<Camera>();
            childrenCamera = this.GetComponentsInChildren<Camera>();
            if( childrenCamera.Length != 2)
            {
                Debug.LogError("There should be two children that have camera component.");
                return;
            }
            originCamera.enabled = false;
            for( int i = 0; i < 2; ++i)
            {
                childrenCamera[i].rect = new Rect(0.5f * i, 0.0f, 0.5f, 1.0f);
            }
        }
        public void Apply()
        {
            if (childrenCamera == null || childrenCamera.Length < 2) { return; }
            //
            // aspect
            for (int i = 0; i < 2; ++i)
            {
                childrenCamera[i].nearClipPlane = originCamera.nearClipPlane;
                childrenCamera[i].farClipPlane = originCamera.farClipPlane;
                childrenCamera[i].fieldOfView = originCamera.fieldOfView;
                childrenCamera[i].aspect = originCamera.aspect;
            }
            childrenCamera[0].transform.localPosition = new Vector3(-eyeDistance * 0.5f, 0.0f, 0.0f);
            childrenCamera[1].transform.localPosition = new Vector3(eyeDistance * 0.5f, 0.0f, 0.0f);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            this.Apply();
        }
    }
}