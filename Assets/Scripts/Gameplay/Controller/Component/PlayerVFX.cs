using System;
using DG.Tweening;
using UnityEngine;
using WitchGate.Gameplay.Controller;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.VFX
{
    public class PlayerVFX : PlayerDirectionListener
    {
        [field: SerializeField] public float XOffSet {get; private set; }

        private void OnEnable()
        {
            base.OnEnable();
            OnDirectionChanged(XOffSet);
        }
        private void Awake()
        {
            
        }

        protected override void OnDirectionChanged(float dir)
        {
            Debug.Log("this is the direction : "+ dir);
            float x = 0;
            if (dir > 0)
            {
                x = XOffSet;
            }
            else
            {
                x = XOffSet*-1;
            }
            Debug.Log("la direction : " + x);
            //this.transform.DOMoveX(x,0);
            this.transform.DOLocalMoveX(x, 0);
        }
    }
}