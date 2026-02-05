using System.Collections.Generic;
using DialogNodeBaseSystem.Plugins.DialogNodeBasedSystem.Scripts.Runtime.Enums;
using UnityEditor;
using UnityEngine;
using WitchGate.Visual_Novel.Enums;
using WitchGate.VisualNovel.Visual_Novel.Dialog;

namespace cherrydev
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Node Graph/Nodes/Stage Node", fileName = "New Stage Node")]
    public class StageNode : Node
    {
        
        [SerializeField] private Stage _stage;
        
        [Space(10)] 
        public List<Node> ParentNodes = new();
        public Node ChildNode;
        
        
        private const float LabelFieldSpace = 47f;
        private const float TextFieldWidth = 100f;
        private const float ExternalNodeHeight = 155f;
        
        public Stage Stage => _stage;
        
#if UNITY_EDITOR

        /// <summary>
        /// Draw Sentence Node method
        /// </summary>
        /// <param name="nodeStyle"></param>
        /// <param name="labelStyle"></param>
        public override void Draw(GUIStyle nodeStyle, GUIStyle labelStyle)
        {
            base.Draw(nodeStyle, labelStyle);

            ParentNodes.RemoveAll(item => item == null);
            
            GUILayout.BeginArea(Rect, nodeStyle);

            EditorGUILayout.LabelField("Stage Node", labelStyle);
            
            DrawCharacterDataFieldHorizontal();
            DrawSlotNameFieldHorizontal();
            DrawExpressionFieldHorizontal();
            DrawVisibilityFieldHorizontal();

            GUILayout.EndArea();
        }
        
        /// <summary>
        /// Removes all connections in a answer node
        /// </summary>
        public override void RemoveAllConnections()
        {
            ParentNodes.Clear();
            ChildNode = null;
        }
        
        public override bool RemoveFromParentConnectedNode(Node nodeToRemove) => 
            ParentNodes.Remove(nodeToRemove);
        
        
        private void DrawCharacterDataFieldHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"VN Character Data ", GUILayout.Width(LabelFieldSpace));
            _stage.CharacterData = (VNCharacterData)EditorGUILayout.ObjectField(_stage.CharacterData,
                typeof(VNCharacterData), false, GUILayout.Width(TextFieldWidth));
            EditorGUILayout.EndHorizontal();
        }

        private void DrawVisibilityFieldHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"Visibility ", GUILayout.Width(LabelFieldSpace));
            _stage.visibility = EditorGUILayout.Toggle(_stage.visibility, GUILayout.Width(TextFieldWidth));
            EditorGUILayout.EndHorizontal();
        }
        
        private void DrawSlotNameFieldHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"Slot Name", GUILayout.Width(LabelFieldSpace));
            _stage.slotName = (SlotName)EditorGUILayout.EnumPopup(_stage.slotName,GUILayout.Width(TextFieldWidth));
            EditorGUILayout.EndHorizontal();
        }
        
        private void DrawExpressionFieldHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"Expression", GUILayout.Width(LabelFieldSpace));
            _stage.expression = (Expression)EditorGUILayout.EnumPopup(_stage.expression,GUILayout.Width(TextFieldWidth));
            EditorGUILayout.EndHorizontal();
        }
        
        
        
         /// <summary>
        /// Adding nodeToAdd Node to the childNode field
        /// </summary>
        /// <param name="nodeToAdd"></param>
        /// <returns></returns>
        public override bool AddToChildConnectedNode(Node nodeToAdd)
        {
            if (nodeToAdd == this)
                return false;

            if (nodeToAdd.GetType() == typeof(SentenceNode))
            {
                SentenceNode sentenceNodeToAdd = (SentenceNode)nodeToAdd;
                if (sentenceNodeToAdd != null && sentenceNodeToAdd.ChildNode == this)
                {
                    Debug.LogWarning("Circular parenting not allowed");
                    return false;
                }
            }
            
            if (nodeToAdd.GetType() == typeof(StageNode))
            {
                StageNode sentenceNodeToAdd = (StageNode)nodeToAdd;
                if (sentenceNodeToAdd != null && sentenceNodeToAdd.ChildNode == this)
                {
                    Debug.LogWarning("Circular parenting not allowed");
                    return false;
                }
            }
    
            if (nodeToAdd.GetType() == typeof(ExternalFunctionNode))
            {
                ExternalFunctionNode externalFunctionNodeToAdd = (ExternalFunctionNode)nodeToAdd;
                
                if (externalFunctionNodeToAdd != null && externalFunctionNodeToAdd.ChildNode == this)
                {
                    Debug.LogWarning("Circular parenting not allowed");
                    return false;
                }
            }

            if (ChildNode != null && ChildNode != nodeToAdd)
                ChildNode.RemoveFromParentConnectedNode(this);

            ChildNode = nodeToAdd;
            return true;
        }
         
         

        /// <summary>
        /// Adding nodeToAdd Node to the parentNode field
        /// </summary>
        /// <param name="nodeToAdd"></param>
        /// <returns></returns>
        public override bool AddToParentConnectedNode(Node nodeToAdd)
        {
            
            if (nodeToAdd == this)
                return false;

            if (ParentNodes.Contains(nodeToAdd))
                return false;

            if (nodeToAdd.GetType() == typeof(SentenceNode) 
                || nodeToAdd.GetType() == typeof(AnswerNode) 
                || nodeToAdd.GetType() == typeof(ModifyVariableNode)
                || nodeToAdd.GetType() == typeof(VariableConditionNode)
                || nodeToAdd.GetType() == typeof(ExternalFunctionNode)
                || nodeToAdd.GetType() == typeof(StageNode))
            {
                ParentNodes.Add(nodeToAdd);
                return true;
            }

            return false;
        }
#endif 
    }
    
}