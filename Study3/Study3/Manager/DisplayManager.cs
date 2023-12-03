using Study3.Character;
using System;

namespace Study3.Manager
{
    internal class DisplayManager
    {
        public static void DisplayTitle()
        {
            Console.WriteLine("***세계에서 가장 재밌는 RPG게임!!***");
            Console.WriteLine("    이름을 입력하고 Enter 입력      \n");
                Console.Write("           이름 : ");

        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("무엇을 할까?");
            Console.WriteLine("1. 스테이터스 갱신 및 열람");
            Console.WriteLine("2. 던전 탐험");
            Console.WriteLine("3. 포션 사용");
            Console.WriteLine("4. 부활(사망시 사용 가능)\n");
            Console.Write("선택 : ");
        }

        public static void DisplayEnterToReturn()
        {
            Console.Write("\n(돌아가려면 Enter 입력)");
            Console.ReadLine();
        }

        public static void DisplayDefault()
        {
            Console.WriteLine("올바른 값 입력");
        }

        public static void DisplaySpotEnemy(CombatableEntity enemy)
        {
            Console.WriteLine("몬스터를 발견했다! 전투를 시작합니다.\n");
            Console.WriteLine($"({enemy.Name})");
            Console.WriteLine($" 체력 : {enemy.HealthPoint} / 공격력 : {enemy.AttackPower} / 방어력 : {enemy.DefensePower}");
        }

        public static void DisplaySelectBattleMenu()
        {
            Console.WriteLine("1. 공격하기 2. 도망가기");
            Console.Write("행동 입력 : ");
        }

        public static void DisplayGameOver()
        {
            Console.WriteLine($"게임 오버! 이어 하고 싶다면 4번 부활을 선택해주세요!");
        }

        public static void DisplayKillEnemy(Enemy enemy)
        {
            Console.WriteLine($"{enemy.Name} 처치에 성공하셨습니다!");
            Console.WriteLine($"전리품으로 경험치{enemy.Exprience}와 {enemy.Name}의 {enemy.DropItem.Name}을 획득합니다!");
        }

        public static void DisplayRunSucceded()
        {
            Console.WriteLine("도망에 성공했다!");
        }

        public static void DisplayRunFailed()
        {
            Console.WriteLine("도망에 실패했다!");
        }
    }
}
