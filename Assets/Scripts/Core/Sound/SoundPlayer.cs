using UnityEngine;

namespace WitchGate.Sound
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource source;

        public void PlaySound(AnimationEvent evt)
        {
            if (source != null && source.clip != null)
            {
                source.PlayOneShot(evt.objectReferenceParameter as AudioClip);
            }
        }
    }
}