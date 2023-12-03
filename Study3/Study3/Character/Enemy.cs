using Study3.Items;

namespace Study3.Character
{
    internal class Enemy : CombatableEntity
    {
        public Item DropItem { get; set; }
        public int Exprience { get; set; }

        // private으로 설정해 builder를 통해서만 Enemy를 생성하도록 설정
        private Enemy() { }

        public static Enemy CreateFromBuilder(EnemyBuilder builder)
        {
            return new Enemy
            {
                Name = builder.name,
                AttackPower = builder.atk,
                DefensePower = builder.def,
                MaxHealthPoint = builder.maxHp,
                HealthPoint = builder.maxHp,
                DropItem = builder.item,
                Exprience = builder.exp
            };
        }
    }

    internal class EnemyBuilder
    {
        public Item item;
        public string name;
        public float maxHp;
        public float atk;
        public float def;
        public int exp;

        public EnemyBuilder SetEnemyProperty(string name, float maxHp, float atk, float def, int exp)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.atk = atk;
            this.def = def;
            this.maxHp = maxHp;
            this.exp = exp;
            return this;
        }

        public EnemyBuilder SetItemProperty(string name, float atk, float def)
        {
            item = new EquipmentItem(name, atk, def);
            return this;
        }

        public EnemyBuilder SetItemProperty(string name, int grade)
        {
            item = new PotionItem(name, grade);
            return this;
        }

        public Enemy Build()
        {
            return Enemy.CreateFromBuilder(this);
        }
    }
}
