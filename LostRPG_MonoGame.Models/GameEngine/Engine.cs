//// ReSharper disable MemberCanBeMadeStatic.Local
namespace LostRPG_MonoGame.Models.GameEngine
{
    using System;
    using System.Linq;
    using LostRPG_MonoGame.Models.Controllers;
    using LostRPG_MonoGame.Models.Interfaces;
    using LostRPG_MonoGame.Models.Structure;
    using LostRPG_MonoGame.Models.Structure.Abilities;
    using LostRPG_MonoGame.Models.Structure.BoostItems;
    using LostRPG_MonoGame.Models.Structure.Units.Character;
    using Microsoft.Xna.Framework;
    public sealed class Engine
    {
        private readonly IUserInputInterface controller;
        private readonly IPaintInterface painter;
        private readonly RegionEntities regionEntities;
        private IGameStateInformation gameStateInformation;


        private TimeSpan totalElapsedTime;
        
        public Engine(IUserInputInterface givenController, IPaintInterface painter, IGameStateInformation gameStateInformation)
        {
            this.controller = givenController;
            this.painter = painter;
            this.totalElapsedTime = TimeSpan.Zero;
            ////
            this.gameStateInformation = gameStateInformation;
            RegionEntities.IntantiateClass(this, this.painter, this.gameStateInformation);
            this.regionEntities = RegionEntities.GetInstance();
            ////
            this.SubscribeToController();
        }

        public void Update(GameTime gameTime)
        {
            this.totalElapsedTime = gameTime.TotalGameTime;
            this.RemoveDeadUnits();
            this.RemoveUsedItems();
            this.painter.RedrawObject(this.regionEntities.Player);
            this.regionEntities.Enemies.ForEach(this.painter.RedrawObject);
            this.regionEntities.Abilities.ForEach(a => a.CurrentLifespanInMS += gameTime.ElapsedGameTime.Milliseconds);
            var timedOutList = this.regionEntities.Abilities.Where(a => a.HasTimedOut).ToList();
            foreach (var timedOutObj in timedOutList)
            {
                this.regionEntities.Abilities.Remove(timedOutObj);
                this.painter.RemoveObject(timedOutObj as IRenderable);
            }
        }

        public void RelocateUnit(int x, int y, IUnit unit)
        {
            throw new NotImplementedException();
        }

        public void RelocatePlayer(int x, int y)
        {

            this.regionEntities.Player.X = x;
            this.regionEntities.Player.Y = y;
        }
        
        ////----------------------------------------------------------------------------------------\\

        private void SubscribeToController()
        {
            this.controller.OnUpPressed += (sender, args) =>
                {
                    this.MovePlayerUp();
                };
            this.controller.OnDownPressed += (sender, args) =>
                {
                    this.MovePlayerDown();
                };
            this.controller.OnRightPressed += (sender, args) =>
                {
                    this.MovePlayerRight();
                };
            this.controller.OnLeftPressed += (sender, args) =>
                {
                    this.MovePlayerLeft();
                };
            this.controller.OnNumericKeyPressed += (sender, args) =>
            {
                this.ChangePlayerActiveAbility(args as NumericKeyEventArgs);
            };
            this.controller.OnLeftMouseClick += (sender, args) =>
            {
                var abilityArgs = args as AbilityEventArgs;
                if (abilityArgs != null)
                {
                    this.UsePlayerAbility(abilityArgs.MouseX, abilityArgs.MouseY);
                }
            };
        }

        private void ChangePlayerActiveAbility(NumericKeyEventArgs args)
        {
            var key = args.NumericValue;
            this.regionEntities.Player.SetActiveAbility(key);
        }

        /// <summary>
        /// The if statements in the following four methods prevent the player from leaving the screen window.        
        /// </summary>
        private void MovePlayerUp()
        {
            this.regionEntities.Player.Direction = new Direction(0, -1);
            if (this.regionEntities.Player.Y > 0)
            {
                this.ProcessPlayerMovement();
            }
        }

        private void MovePlayerDown()
        {
            this.regionEntities.Player.Direction = new Direction(0, 1);
            if (this.regionEntities.Player.Y + this.regionEntities.Player.SizeY < 720)
            {
                this.ProcessPlayerMovement();
            }
        }

        private void MovePlayerRight()
        {
            this.regionEntities.Player.Direction = new Direction(1, 0);
            if (this.regionEntities.Player.X + this.regionEntities.Player.SizeX < 1280)
            {
                this.ProcessPlayerMovement();
            }
        }

        private void MovePlayerLeft()
        {
            this.regionEntities.Player.Direction = new Direction(-1, 0);
            if (this.regionEntities.Player.X > 0)
            {
                this.ProcessPlayerMovement();
            }
        }

        private void ProcessPlayerMovement()
        {
            ////TODO : Process collision in seperate class CollisionHandler
            var buffX = this.regionEntities.Player.X;
            var buffY = this.regionEntities.Player.Y;
            this.regionEntities.Player.Move();
            var colisionDetected = false;
            foreach (var obstacle in this.regionEntities.Obstacles)
            {
                if (this.DoIntersect(this.regionEntities.Player, obstacle))
                {
                    colisionDetected = true;
                    break;
                }
            }

            foreach (var enemy in this.regionEntities.Enemies)
            {
                if (this.DoIntersect(this.regionEntities.Player, enemy))
                {
                    colisionDetected = true;
                    break;
                }
            }

            foreach (var friendlyNpcUnit in this.regionEntities.FriendlyNPCs)
            {
                if (this.DoIntersect(this.regionEntities.Player, friendlyNpcUnit))
                {
                    colisionDetected = true;
                
                    break;
                }
            }

            foreach (var item in this.regionEntities.Items)
            {
                if (this.DoIntersect(this.regionEntities.Player, item))
                {
                    this.ApplyItemEffect(item, this.regionEntities.Player);
                    item.HasBeenUsed = true;
                }
            }

            if (colisionDetected)
            {
                this.RelocatePlayer(buffX, buffY);
            }

            ////Check for gateways
            foreach (var gateway in this.regionEntities.Gateways)
            {
                if (this.DoIntersect(this.regionEntities.Player, gateway))
                {
                    gateway.TriggerAction();
                    break;
                }
            }
        }

        private void ApplyItemEffect(Item item, ICharacterUnit player)
        {
            item.ApplyItemEffects(player);
            this.painter.RedrawObjectWithAShield(player);                      
        }

        private void UsePlayerAbility(int mouseX, int mouseY)
        {
            if (this.regionEntities.Player is Warrior)
            {
                var meleeAbility = ((Warrior)this.regionEntities.Player).MeleeAttack(mouseX, mouseY, this.totalElapsedTime);
                ////Ability Logic
                if (meleeAbility == null)
                {
                    return;
                }

                if (meleeAbility is BasicAttack)
                {
                    this.regionEntities.Abilities.Add(meleeAbility);
                    this.painter.AddObject(meleeAbility as IRenderable);
                    this.ProcessAreaAbilityEffect(meleeAbility);
                }
                else if (meleeAbility is Charge)
                {
                    var mouseRect = new DisposableGameObject(mouseX, mouseY, 1, 1);
                    //// Check range restr.
                    if (this.DoIntersect(meleeAbility, mouseRect))
                    {
                        foreach (var enemyNpcUnit in this.regionEntities.Enemies)
                        {
                            if (this.DoIntersect(mouseRect, enemyNpcUnit))
                            {
                                this.RelocatePlayer(mouseX, mouseY);
                            }
                        }
                    }
                }
            }
            ////else if.. - other character classes
        }

        private void ProcessAreaAbilityEffect(Ability ability)
        {
            var hitTargets = this.regionEntities.Enemies.Where(e => this.DoIntersect(ability, e)).ToList();
            foreach (var hitEnemy in hitTargets)
            {
                var reaction = hitEnemy.ReactToAbility(ability.AbilityEffect);
                switch (reaction)
                {
                    case ReactionTypeEnum.TakeDamage:
                        {
                            var damage = ability.Power + ability.Caster.AttackPoints - hitEnemy.DefensePoints;
                            hitEnemy.CurrentHP -= damage;
                            ////var damageBack = hitEnemy.AttackPoints;
                            ////regionEntities.Player.CurrentHP -= damageBack;
                            break;
                        }

                    case ReactionTypeEnum.TakeShield:
                        break;
                    case ReactionTypeEnum.TakeHeal:
                        break;
                    case ReactionTypeEnum.TakeBuff:
                        break;
                    case ReactionTypeEnum.TakeDebuff:
                        break;
                    case ReactionTypeEnum.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private bool DoIntersect(IGameObject objA, IGameObject objB)
        {
            int rectAx1 = objA.X;
            int rectAx2 = objA.X + objA.SizeX;
            int rectAy1 = objA.Y;
            int rectAy2 = objA.Y + objA.SizeY;
                
            int rectBx1 = objB.X;
            int rectBx2 = objB.X + objB.SizeX;
            int rectBy1 = objB.Y;
            int rectBy2 = objB.Y + objB.SizeY;

            if (rectAx1 < rectBx2 &&
                rectAx2 > rectBx1 &&
                rectAy1 < rectBy2 &&
                rectAy2 > rectBy1)
            {
                return true;
            }

            return false;
        }

        private void ProcessProjectileMovement(IMoveable movableObject)
        {
            throw new NotImplementedException();
        }

        private void RemoveDeadUnits()
        {
            var deadUnits = this.regionEntities.Enemies.Where(e => !e.IsAlive).ToList();
            foreach (var deadUnit in deadUnits)
            {
                this.regionEntities.Enemies.Remove(deadUnit);
                this.painter.RemoveObject(deadUnit);
            }
        }

        private void RemoveUsedItems()
        {
            var usedItems = this.regionEntities.Items.Where(e => e.HasBeenUsed).ToList();
            foreach (var usedItem in usedItems)
            {
                this.regionEntities.Items.Remove(usedItem);
                this.painter.RemoveObject(usedItem);
            }
        }
    }
}
