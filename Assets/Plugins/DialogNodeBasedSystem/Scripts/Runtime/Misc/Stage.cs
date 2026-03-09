using DialogNodeBaseSystem.Plugins.DialogNodeBasedSystem.Scripts.Runtime.Enums;

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