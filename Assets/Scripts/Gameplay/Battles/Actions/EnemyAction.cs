using System.Collections.Generic;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyAction : ITurnAction
    {
        public event Action OnConfirmationChanged;
        public int Priority { get; set; }
        public string Label => gameCard.CardData.Name;
        public IGameCard GameCard => gameCard;
        
        private readonly IGameCard gameCard;
        private readonly BattlePhase battlePhase;

        public bool IsConfirmed { get; private set; }
        
        public EnemyAction(IGameCard gameCard, BattlePhase battlePhase)
        {
            this.gameCard = gameCard;
            this.battlePhase = battlePhase;
            Priority = gameCard.CardData.Priority;
            IsConfirmed = false;
        }


        public async Awaitable Execute()
        {
            await gameCard.Use(GetTargetedWitch(), battlePhase.Enemy);
            battlePhase.Enemy.Discard.TryAddCard(gameCard);
        }

        private List<ICanFight> GetTargetedWitch()
        {
            List<ICanFight> target = new List<ICanFight>();
            switch (gameCard.WitchDeck)
            {
                case Witch.Elaris:
                    target.Add(battlePhase.GetBattleWich(Witch.Elaris));
                    break;

                case Witch.Velmora:
                    target.Add(battlePhase.GetBattleWich(Witch.Velmora));
                    break;

                default :
                    target.Add(battlePhase.GetBattleWich(Witch.Elaris));
                    target.Add(battlePhase.GetBattleWich(Witch.Velmora));
                    break;
            }
            target.Add(battlePhase.Enemy);
            return target;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}