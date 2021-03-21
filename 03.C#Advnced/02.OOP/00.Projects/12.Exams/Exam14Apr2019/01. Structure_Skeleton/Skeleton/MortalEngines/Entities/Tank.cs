namespace MortalEngines.Entities
{
    using System.Text;

    using Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double INIT_HEALTH = 100;
        private const double CHANGE_ATTACK_POINTS = 40;
        private const double CHANGE_DEFENCE_POINTS = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INIT_HEALTH)
        {
            this.DefenseMode = true;

            this.AttackPoints -= CHANGE_ATTACK_POINTS;
            this.DefensePoints += CHANGE_DEFENCE_POINTS;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;

                this.AttackPoints += CHANGE_ATTACK_POINTS;
                this.DefensePoints -= CHANGE_DEFENCE_POINTS;
            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= CHANGE_ATTACK_POINTS;
                this.DefensePoints += CHANGE_DEFENCE_POINTS;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var defense = this.DefenseMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Defense: {defense}");

            return sb.ToString().TrimEnd();
        }
    }
}

