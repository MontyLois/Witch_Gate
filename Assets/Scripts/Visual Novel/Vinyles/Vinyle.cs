using System;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Prototype.Enums;
using WitchGate.Sound;
using WitchGate.VisualNovel.Visual_Novel.Enums;

namespace WitchGate.Prototype.Vinyles
{
    public class Vinyle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private String vinyleName;

        [field: SerializeField] 
        public int VinyleNumber { get; private set; } = 1; 
        
        [field : SerializeField]
        public MusicManager MusicManager { get; private set; }

        [field : SerializeField]
        private Mood[] moods;

        [field : SerializeField]
        private AudioClip vinyleMusic;
        

        public void OnClick()
        {
            MusicManager.SelectBackgroundMusic(vinyleMusic);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            MusicManager.PlayMusic(vinyleMusic);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MusicManager.ResetBackgroundMusic();
        }
    }
}