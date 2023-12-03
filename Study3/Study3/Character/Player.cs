using Study3.Items;

namespace Study3.Character
{
    internal class Player : CombatableEntity
    {
        public List<Item> EquipmentList { get; set; }
        public List<Item> PotionList { get; set; }
        public int Experience { get; set; }
        private int level;
        private readonly string whiteSpace = "    ";

        public Player()
        {
            EquipmentList = new List<Item>();
            PotionList = new List<Item>();
            AttackPower = 0.0f;
            DefensePower = 0.0f;
            MaxHealthPoint = 100.0f;
            HealthPoint = 100.0f;
            Experience = 0;
            level = 0;
        }

        private void CalculateLevel()
        {
            level = Experience / 100 + 1;
        }
        private float CalculateBaseCombatPower()
        {
            CalculateLevel();
            return level * 10;
        }
        public void CalculateCombatPower()
        {
            float baseCombatPower = CalculateBaseCombatPower();
            AttackPower = DefensePower = baseCombatPower;

            foreach (var item in EquipmentList)
            {
                if (item is EquipmentItem)
                {
                    EquipmentItem equipItem = (EquipmentItem)item;
                    AttackPower += equipItem.AttackPower;
                    DefensePower += equipItem.DefensePower;
                }
            }
        }
        private void ShowEquipmentList()
        {
            Console.WriteLine($"{whiteSpace}장비 목록");
            Console.Write($"{whiteSpace}");

            if (EquipmentList.Count() == 0)
            {
                Console.WriteLine("(없음)");
                return;
            }
            foreach (var item in EquipmentList)
            {
                Console.Write($"({item.Name}) ");
            }
        }
        private void showPotionList()
        {
            Console.WriteLine($"{whiteSpace}소지 포션 목록");
            Console.Write($"{whiteSpace}");
            if (PotionList.Count() == 0)
            {
                Console.WriteLine("(없음)");
                return;
            }

            foreach (var item in PotionList)
            {
                if (item is PotionItem)
                {
                    PotionItem potionItem = (PotionItem)item;
                    Console.Write($"({item.Name}) ");
                }
            }
            Console.WriteLine("\n");
        }
        public void ShowPlayerStatus()
        {
            CalculateCombatPower();

            Console.WriteLine("\n--------스테이터스--------");
            Console.WriteLine($"{whiteSpace}{this.Name} / 레벨 : {level}");
            Console.WriteLine($"{whiteSpace}경험치 : {Experience}\n");
            ShowEquipmentList();
            Console.WriteLine($"\n{whiteSpace}공격력 : {AttackPower}");
            Console.WriteLine($"{whiteSpace}방어력 : {DefensePower}");
            Console.WriteLine($"{whiteSpace}체력 : {HealthPoint}\n");
            showPotionList();
        }
        public void UsePotion()
        {
            showPotionList();

            Console.Write("사용할 포션의 번호 입력 : ");

            if (int.TryParse(Console.ReadLine(), out int potionIndex) && potionIndex >= 1 && potionIndex <= PotionList.Count)
            {
                // 선택한 포션 인덱스에 해당하는 포션 사용
                PotionItem selectedPotion = (PotionItem)PotionList[potionIndex - 1];
                Console.WriteLine($"선택한 포션: {selectedPotion.Name}");

                // 체력 회복
                HealthPoint += selectedPotion.GetRecoveryAmount();

                // 사용한 포션 제거
                PotionList.RemoveAt(potionIndex - 1);
            }
            else
            {
                Console.WriteLine("올바른 번호를 입력하세요.");
            }
        }

        public void resurrection()
        {
            if (HealthPoint == 0) HealthPoint = MaxHealthPoint;
        }
    }
}
