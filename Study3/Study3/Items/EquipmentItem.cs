namespace Study3.Items
{
    internal class EquipmentItem : Item
    {
        public float AttackPower { get; }
        public float DefensePower { get; }

        public EquipmentItem(string name, float atk, float def) : base(name)
        {
            AttackPower = atk;
            DefensePower = def;
        }
    }
}
