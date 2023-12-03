using Study3.Character;
using Study3.Items;
using System.Numerics;

namespace Study3.Manager
{
    internal class BattleManager
    {
        public static void AttackEntity(CombatableEntity entity1, CombatableEntity entity2, ref bool bEntityDead)
        {
            entity2.TakeDamage(entity1.AttackPower - entity2.DefensePower);
            Console.WriteLine($"{entity1.Name} 공격! {entity2.Name}의 남은 체력 : {entity2.HealthPoint}");
            Console.WriteLine();

            if (IsEntityDead(entity2))
            {
                CallEntityDead(entity1, entity2);
                bEntityDead = true;
            }
        }

        private static bool IsEntityDead(CombatableEntity entity)
        {
            if (entity.HealthPoint == 0) return true;
            return false;
        }

        private static void CallEntityDead(CombatableEntity entity1, CombatableEntity entity2)
        {
            if(entity2 is Player)
            {
                Player player = (Player)entity2;
                PlayerDead(player);
                return;
            }
            if(entity2 is Enemy)
            {
                Player player = (Player)entity1;
                Enemy enemy = (Enemy)entity2;
                EnemyDead(player, enemy);
                return;
            }
        }

        private static void PlayerDead(Player player)
        {
            Console.Clear();
            DisplayManager.DisplayGameOver();
        }

        private static void EnemyDead(Player player, Enemy enemy)
        {
            Console.Clear();
            DisplayManager.DisplayKillEnemy(enemy);
            player.Experience += enemy.Exprience;
            if (enemy.DropItem is EquipmentItem)
            {
                EquipmentItem equip = (EquipmentItem)enemy.DropItem;
                player.EquipmentList.Add(equip);
                return;
            }
            if (enemy.DropItem is PotionItem)
            {
                PotionItem potion = (PotionItem)enemy.DropItem;
                player.PotionList.Add(potion);
                return;
            }
        }

        public static bool IsRunSucceded()
        {
            Random rand = new Random();
            
            if(rand.Next(1, 101) > 50) return true;
            return false;
        }

        public static void RestoreEnemyHP(CombatableEntity enemy)
        {
            enemy.HealthPoint = enemy.MaxHealthPoint;
        }
    }
}
