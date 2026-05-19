using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.VisualNovel.Visual_Novel.Visions
{
    public class VisionUI : MonoBehaviour
    {
        [field: SerializeField] public GameObject Vision { get; private set; }
        [field: SerializeField] public Image VisionSprite { get; private set; }
        
        

        public void ShowVision(Sprite sprite)
        {
            Debug.Log(sprite);
            if (sprite is null)
                return;
            Vision.SetActive(true);
            VisionSprite.sprite = sprite;    
        }

        public void HideVision()
        {
            Vision.SetActive(false);
        }
    }
}