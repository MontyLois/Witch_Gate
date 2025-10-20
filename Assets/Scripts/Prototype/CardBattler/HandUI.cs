using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

namespace WitchGate.Prototype
{
    public class HandUI : MonoBehaviour
    {
        [SerializeField] private int maxHandSize;
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private SplineContainer splineContainer;
        [SerializeField] private Transform spawnpoint;

        private List<GameObject> handCards = new List<GameObject>();

        [Header("Card Positionning")] 
        private float cardSpacing;
        private float firstCardPosition;
        private Spline spline;
        private Vector3 splinePosition;
        private Vector3 forward;
        private Vector3 up;
        private Quaternion rotation;

        public void Awake()
        {
            cardSpacing = 1f / maxHandSize;
            spline = splineContainer.Spline;
        }
        

        public void AddCardToHand(GameObject card)
        {
            handCards.Add(card);
            card.transform.SetParent(spawnpoint);
            UpdateCardPosition();
        }

        public void RemoveCardToHand(GameObject card)
        {
            handCards.Remove(card);
        }
        private void UpdateCardPosition()
        {
            if(handCards.Count ==0) return;
            firstCardPosition = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
            spline = splineContainer.Spline;
            
            for (int i = 0; i < handCards.Count; i++)
            {
                float position = firstCardPosition + i * cardSpacing;
                splinePosition = spline.EvaluatePosition(position);
                forward = spline.EvaluateTangent(position);
                up = spline.EvaluateUpVector(position);
                Vector3 carPosition = handCards[i].transform.position;
                rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
                handCards[i].transform.DOLocalMove(splinePosition, 0.25f);
                handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
                
                //set their base position
                CardUI cardUI = handCards[i].GetComponent<CardUI>();
                cardUI.SetPosition(splinePosition);
            }
        }
    }
}
