using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Stereo3DExt.TimelineExtention
{
	public class Stereo3DMixerPlayable : PlayableBehaviour
	{


        public override void ProcessFrame(Playable playable, FrameData info, object playerData){
            StereoCameraController controller = playerData as StereoCameraController;
            if(controller == null) { return; }

            controller.eyeDistance = 0.0f;
            int cnt  = playable.GetInputCount();
            for(int i = 0; i < cnt; ++i)
            {
                float inputWeight = playable.GetInputWeight(i);
                if( inputWeight <= float.Epsilon ) { continue; }
                ScriptPlayable<Stereo3DPlayable> scriptPlayable = (ScriptPlayable<Stereo3DPlayable>)playable.GetInput(i);
                Stereo3DPlayable input = scriptPlayable.GetBehaviour();
                controller.eyeDistance += inputWeight * input.eyeDistance;
            }
            controller.Apply();
        }

    }
}