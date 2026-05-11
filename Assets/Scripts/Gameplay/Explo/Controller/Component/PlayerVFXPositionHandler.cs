using DG.Tweening;
using UnityEngine;
using WitchGate.Gameplay.Explo.Controller.Component.Helpers;

namespace WitchGate.Gameplay.Explo.Controller.Component
{
    public class PlayerVFXPositionHandler : PlayerComponent
    {
        [field: SerializeField] public float XOffSet {get; private set; }
        [field: SerializeField] public GameObject Vfx { get; private set; }
        
        private PlayerDirectionListener directionListener = new();

        private void OnEnable()
        {
            directionListener.Bind(Manager.Body, OnDirectionChanged);
        }

        private void OnDisable()
        {
            directionListener.Unbind(Manager.Body, OnDirectionChanged);
        }

        private void OnDirectionChanged(float dir)
        {
            float x = 0;
            if (Mathf.Sign(dir) < 0)
            {
                x = XOffSet;
            }
            else
            {
                x = XOffSet*(-1);
            }
            Vfx.transform.DOLocalMoveX(x, 0.1f);
        }
    }
}