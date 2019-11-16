using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Stereo3DExt.TimelineExtention
{
	public class Stereo3DPlayable : PlayableBehaviour
	{
        public float eyeDistance = 0.0f;
        public void SetData(Stereo3DClip clip)
        {
            this.eyeDistance = clip.eyeDistance;
        }


    }
}