using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Stereo3DExt.TimelineExtention
{
	[TrackClipType(typeof(Stereo3DClip))]
    [TrackBindingType(typeof(StereoCameraController))]
	public class Stereo3DTrack : TrackAsset {

#if UNITY_EDITOR
        private PlayableDirector playableDirector;
#endif

        protected override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip)
        {
            Stereo3DClip enemyClip = clip.asset as Stereo3DClip;
#if UNITY_EDITOR
            this.playableDirector = gameObject.GetComponent<PlayableDirector>();
#endif            
            return base.CreatePlayable(graph, gameObject, clip);
        }


        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<Stereo3DMixerPlayable>.Create(graph, inputCount);
        }

#if UNITY_EDITOR
        public void RebuildGraph()
        {
            if (playableDirector != null)
            {
                playableDirector.RebuildGraph();
                playableDirector.Evaluate();
            }
        }
#endif
    }
}