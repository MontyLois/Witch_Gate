using UnityEngine;

namespace WitchGate.Sound
{
    public class MusicManager: MonoBehaviour
    {
        public AudioSource musicSource;

        private AudioClip currentBackgroundMusic;

        public void PlayMusic(AudioClip newClip)
        {
            if (musicSource.clip == newClip)
                return;

            musicSource.clip = newClip;
            musicSource.Play();
        }

        public void SelectBackgroundMusic(AudioClip newClip)
        {
            currentBackgroundMusic = newClip;
            PlayMusic(newClip);
        }

        public void ResetBackgroundMusic()
        {
            if (musicSource.clip == currentBackgroundMusic)
                return;

            musicSource.clip = currentBackgroundMusic;
            musicSource.Play();
        }
    }
    
}