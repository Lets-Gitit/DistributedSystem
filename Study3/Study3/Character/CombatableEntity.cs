namespace Study3.Character
{
    abstract class CombatableEntity
    {
        public string? Name { get; set; }
        public float AttackPower { get; set; }
        public float DefensePower { get; set; }
        public float MaxHealthPoint { get; set; }
        public float HealthPoint { get; set; }

        public virtual void TakeDamage(float amount)
        {
            HealthPoint -= amount;

            if (HealthPoint <= 0) {
                HealthPoint = 0;
                return;
            }
            if (HealthPoint >= MaxHealthPoint) {
                HealthPoint = MaxHealthPoint;
                return;
            }
        }
    }
}
