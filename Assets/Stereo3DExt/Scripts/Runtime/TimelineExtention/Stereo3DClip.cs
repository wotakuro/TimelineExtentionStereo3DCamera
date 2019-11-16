using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Stereo3DExt.TimelineExtention
{
	public class Stereo3DClip : PlayableAsset, ITimelineClipAsset
	{

        [SerializeField]
        public float eyeDistance = 0.05f;
        

        public ClipCaps clipCaps
		{
			get { return ClipCaps.Blending; }
		}

        public GameObject prefab
        {
            get;set;
        }
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<Stereo3DPlayable>.Create(graph);
            var behaviour = playable.GetBehaviour();
            behaviour.SetData( this );
			return playable;   
		}
	}
}