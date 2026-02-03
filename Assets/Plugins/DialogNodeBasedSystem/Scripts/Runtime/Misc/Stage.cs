using DialogNodeBaseSystem.Plugins.DialogNodeBasedSystem.Scripts.Runtime.Enums;
using WitchGate.Visual_Novel.Enums;
using WitchGate.VisualNovel.Visual_Novel.Dialog;

namespace cherrydev
{
    [System.Serializable]
    public struct Stage
    {
        public VNCharacterData CharacterData;
        public bool visibility;
        public Expression expression;
        public SlotName slotName;
        
    }
}