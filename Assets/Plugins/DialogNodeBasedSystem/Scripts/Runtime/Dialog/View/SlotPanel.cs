using System;
using System.Collections.Generic;
using DialogNodeBaseSystem.Plugins.DialogNodeBasedSystem.Scripts.Runtime.Enums;
using Febucci.TextAnimatorCore.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WitchGate.Visual_Novel.Enums;
using WitchGate.VisualNovel.Visual_Novel.Dialog;

namespace cherrydev
{
    public class SlotPanel : MonoBehaviour
    {
        [Header("Slot")] 
        [SerializeField] private SlotName SlotName;
        
        [Header("Text Slot")]
        [SerializeField] private GameObject _textSlot;
        [SerializeField] private TextMeshProUGUI _dialogNameText;
        [SerializeField] private TextMeshProUGUI _dialogText;
        
        
        [SerializeField] private Image _dialogCharacterImage;
        
        [Header("Character Slot")]
        [SerializeField] private GameObject _characterSlot;
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private Dictionary<VNCharacterData, GameObject> _charactersInSlot;

        [Header("Behavior")] 
        [SerializeField] private bool hideWhenAnswering;
        [SerializeField] private bool hideCharOnNextDialog;
        [SerializeField] private bool hideTextOneNextDialog;

        private string _currentFullText;


        private void Awake()
        {
            _charactersInSlot = new Dictionary<VNCharacterData, GameObject>();
        }

        /// <summary>
        /// Setting dialogText max visible characters to zero
        /// </summary>
        public void ResetDialogText()
        {
            _dialogText.maxVisibleCharacters = 0;
            _currentFullText = string.Empty;
        }

        /// <summary>
        /// Set dialog text max visible characters to dialog text length
        /// </summary>
        /// <param name="text"></param>
        public void ShowFullDialogText(string text)
        {
            //_currentFullText = text;
            //_dialogText.text = text;
            _dialogText.maxVisibleCharacters = _dialogText.text.Length;
        }

        /// <summary>
        /// Increasing max visible characters
        /// </summary>
        public void IncreaseMaxVisibleCharacters() => _dialogText.maxVisibleCharacters++;
        
        /// <summary>
        /// Assigning dialog name text, character image sprite and dialog text
        /// </summary>
        public void Setup(string characterName, string text, Sprite sprite)
        {
            
            Debug.Log("olala");
            
            _dialogNameText.text = characterName;
            _dialogText.text = text;
            _currentFullText = text;

            if (sprite == null)
            {
                _dialogCharacterImage.color = new Color(_dialogCharacterImage.color.r,
                    _dialogCharacterImage.color.g, _dialogCharacterImage.color.b, 0);
                return;
            }

            _dialogCharacterImage.color = new Color(_dialogCharacterImage.color.r,
                _dialogCharacterImage.color.g, _dialogCharacterImage.color.b, 255);
            _dialogCharacterImage.sprite = sprite;
        }

        public void Setup(VNCharacterData characterData, string text)
        {
            Debug.Log("donc là on est dans le deuxième settup");
            
            _dialogNameText.text = characterData.name;
            _dialogText.text = text;
            _currentFullText = text;
        }


        public void OnStageNode(VNCharacterData characterData, bool visibility, Expression expression, SlotName slotName)
        {
            if(!characterData)
                return;
            
            if (SlotName == slotName)
            {
                Debug.Log("we are in the right slot");
                if (!_charactersInSlot.ContainsKey(characterData))
                {
                    AddCharacterToSlot(characterData);
                }
                _characterSlot.SetActive(true);
                ChangeCharacterVisibility(characterData, visibility);
                ChangeCharacterExpression(characterData, expression);
            }
            else
            {
                Debug.Log("we are NOT in the right slot");
                if (_charactersInSlot.ContainsKey(characterData))
                {
                    RemoveCharacterToSlot(characterData);
                }
            }
        }

        public void OnDialogNode(VNCharacterData characterData, string text)
        {
            if (_charactersInSlot.ContainsKey(characterData))
            {
                Debug.Log("character here");
                _textSlot.SetActive(true);
                _characterSlot.SetActive(true);
                ChangeText(characterData, text);
            }
            else
            {
                Debug.Log("character not here");
                if (hideCharOnNextDialog)
                {
                    _characterSlot.SetActive(false);
                }
                if (hideTextOneNextDialog)
                {
                    _textSlot.SetActive(false);
                }
            }
        }

        public void OnAnswerNode()
        {
            if (hideWhenAnswering)
            {
                _characterSlot.SetActive(false);
                _textSlot.SetActive(false);
            }
        }

        private void ChangeText(VNCharacterData characterData, string text)
        {
            _dialogNameText.text = characterData.name;
            _dialogText.text = text;
            _currentFullText = text;
        }
        
        //Instantiate new character with default expression sprite, and add the character to the dictionary
        private void AddCharacterToSlot(VNCharacterData characterData)
        {
            if(_charactersInSlot.ContainsKey(characterData))
                return;
            
            Debug.Log("we are adding the character to this slot");
            GameObject characterImage = Instantiate(_characterPrefab, _characterSlot.transform);
            SetSprite(characterImage, characterData.GetSprite(Expression.Neutral));
            _charactersInSlot.Add(characterData, characterImage);
        }

        //Destroy old gameobject of the character and remove it from the list
        private void RemoveCharacterToSlot(VNCharacterData characterData)
        {
            if(!_charactersInSlot.ContainsKey(characterData))
                return;
            
            Destroy(_charactersInSlot[characterData]);
            _charactersInSlot.Remove(characterData);
        }

        private void ChangeCharacterVisibility(VNCharacterData characterData, bool showCharacter)
        {
            _charactersInSlot[characterData].SetActive(showCharacter);
        }

        private void ChangeCharacterExpression(VNCharacterData characterData, Expression NewExpression)
        {
            SetSprite(_charactersInSlot[characterData],characterData.GetSprite(NewExpression));
        }
        
        private void SetSprite(GameObject characterImageGO, Sprite newImage)
        {
            characterImageGO.GetComponent<Image>().sprite = newImage;
        }
    }
}