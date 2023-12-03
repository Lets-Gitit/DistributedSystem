namespace Study3.Items
{
    internal class PotionItem : Item
    {
        public int PotionGrade { get; }

        public PotionItem(string name, int grade) : base(name)
        {
            if (grade > 0) grade = 1;
            PotionGrade = grade;
        }

        public int GetRecoveryAmount()
        {
            // 등급에 따라 다른 회복량 계산 로직
            // 예시로 간단히 등급 * 10으로 가정
            return PotionGrade * 10;
        }
    }
}
