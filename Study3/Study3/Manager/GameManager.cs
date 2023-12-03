using Study3.Character;
using System;

namespace Study3.Manager
{
    internal class GameManager
    {
        private Player player;
        private List<CombatableEntity> enemyList;

        public GameManager()
        {
            player = new Player();
            enemyList = new List<CombatableEntity>();
        }

        public void GameStart()
        {
            CreateEntities();
            DisplayManager.DisplayTitle();
            SetPlayerName(Console.ReadLine());

            while (true)
            {
                DisplayManager.DisplayMenu();
                SelectMenu();
                DisplayManager.DisplayEnterToReturn();
            }
        }

        private void SetPlayerName(string name)
        {
            player.Name = string.IsNullOrWhiteSpace(name) ? "플레이어" : name;
        }

        private void SelectMenu()
        {
            int selectedMenu = 0;

            if (int.TryParse(Console.ReadLine(), out int input))
                selectedMenu = input;

            switch (selectedMenu)
            {
                case 1: player.ShowPlayerStatus(); break;
                case 2: ExploreDungeon(); break;
                case 3: player.UsePotion(); break;
                case 4: player.resurrection(); break;
                default: DisplayManager.DisplayDefault(); break;
            }
        }

        private int GetRandomInt(int min, int max)
        {
            // rand 인스턴스는 ExploreDungeon가 실행되는 동안 유지될 필요가 없음. 역할 수행 후 삭제되도록 별도 함수화.
            Random rand = new Random();
            return rand.Next(min, max);
        }

        private void ExploreDungeon()
        {
            CombatableEntity enemy = enemyList[GetRandomInt(0, enemyList.Count())];
            bool bEndBattle = false;

            // 전투 시작 전 플레이어 스테이터스 갱신
            player.CalculateCombatPower();
            DisplayManager.DisplaySpotEnemy(enemy);

            while (!bEndBattle)
            {
                bEndBattle = DoBattle(player, enemy);
            }
        }

        private bool DoBattle(CombatableEntity player, CombatableEntity enemy)
        {
            int battleMenu = 0;
            bool bEntityDead = false;

            DisplayManager.DisplaySelectBattleMenu();
            if (int.TryParse(Console.ReadLine(), out int input))
                battleMenu = input;

            switch (battleMenu)
            {
                case 1:
                    BattleManager.AttackEntity(player, enemy, ref bEntityDead);
                    if (bEntityDead)
                    {
                        enemyList.Remove(enemy);
                        return true;
                    }
                    BattleManager.AttackEntity(enemy, player, ref bEntityDead);
                    if (bEntityDead)
                    {
                        return true;
                    }
                    break;
                case 2:
                    bool bRunSuccessful = BattleManager.IsRunSucceded();
                    if (bRunSuccessful)
                    {
                        DisplayManager.DisplayRunSucceded();
                        BattleManager.RestoreEnemyHP(enemy);
                        return true;
                    }
                    if (!bRunSuccessful)
                    {
                        DisplayManager.DisplayRunFailed();
                        BattleManager.AttackEntity(enemy, player, ref bEntityDead);
                        return false;
                    }
                    break;
                default:
                    DisplayManager.DisplayDefault();
                    return false;
            }

            return false;
        }

        private void CreateEntities()
        {
            CreatePlayer();

            /* 적을 생성하는 함수 호출, 매개변수가 많기 때문에 실제 게임에선 DB, 파일 시스템 등 활용. */

            // 적, 장비 아이템 보유
            CreateEnemy("슬라임", 20, 12.0f, 2.0f, 40, "나무 헬멧", 0.0f, 3.0f);
            CreateEnemy("고블린", 40, 12.0f, 6.0f, 40, "철 갑옷 상의", 0.0f, 12.0f);
            CreateEnemy("불의 정령", 50, 18.0f, 6.0f, 40, "철 갑옷 하의", 0.0f, 12.0f);
            CreateEnemy("도마뱀", 40, 15.0f, 2.0f, 40, "날카로운 검", 8.0f, 0.0f);

            // 적, 포션 아이템 보유
            CreateEnemy("고블린", 40, 12.0f, 6.0f, 40, "1티어 포션", 1);
            CreateEnemy("불의 정령", 50, 18.0f, 6.0f, 40, "2티어 포션", 2);
            CreateEnemy("도마뱀", 40, 15.0f, 2.0f, 40, "3티어 포션", 3);
        }

        // 플레이어 생성
        private void CreatePlayer()
        {
            Player player = new Player();
        }

        // 몬스터 생성, 장비 아이템 보유 (오버로딩)
        private void CreateEnemy(string enemyName, int maxHp, float enemyAtk, float enemyDef, int exp, string itemName, float itemAtk, float itemDef)
        {
            // 빌더 패턴, 생성된 EnemyBuilder는 함수가 종료되며 가비지 컬렉터가 수거
            Enemy enemy = new EnemyBuilder()
                .SetEnemyProperty(enemyName, maxHp, enemyAtk, enemyDef, exp)
                .SetItemProperty(itemName, itemAtk, itemDef)
                .Build();

            enemyList.Add(enemy);
        }

        // 몬스터 생성, 포션 아이템 보유 (오버로딩)
        private void CreateEnemy(string enemyName, int maxHp, float enemyAtk, float enemyDef, int exp, string itemName, int grade)
        {
            // 빌더 패턴, 생성된 EnemyBuilder는 함수가 종료되며 가비지 컬렉터가 수거
            Enemy enemy = new EnemyBuilder()
                .SetEnemyProperty(enemyName, maxHp, enemyAtk, enemyDef, exp)
                .SetItemProperty(itemName, grade)
                .Build();

            enemyList.Add(enemy);
        }
    }
}
