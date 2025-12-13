using System;
using DG.Tweening;
using UnityEngine;
using WitchGate.Gameplay.Controller;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.VFX
{
    public class PlayerVFXPositionHandler : PlayerDirectionListener
    {
        [field: SerializeField] public float XOffSet {get; private set; }

        private void OnEnable()
        {
            base.OnEnable();
            OnDirectionChanged(XOffSet);
        }

        protected override void OnDirectionChanged(float dir)
        {
            float x = 0;
            if (dir > 0)
            {
                x = XOffSet;
            }
            else
            {
                x = XOffSet*-1;
            }
            this.transform.DOLocalMoveX(x, 0);
        }
    }
}