namespace MortalEngines.Entities
{
    using System.Text;

    using Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const double INIT_HEALTH = 200;

        private const double CHANGE_ATTACK_POINTS = 50;
        private const double CHANGE_DEFENCE_POINTS = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INIT_HEALTH)
        {
            this.AggressiveMode = true;
            this.AttackPoints += CHANGE_ATTACK_POINTS;
            this.DefensePoints -= CHANGE_DEFENCE_POINTS;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= CHANGE_ATTACK_POINTS;
                this.DefensePoints += CHANGE_DEFENCE_POINTS;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += CHANGE_ATTACK_POINTS;
                this.DefensePoints -= CHANGE_DEFENCE_POINTS;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var aggressive = this.AggressiveMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Aggressive: {aggressive}");

            return sb.ToString().TrimEnd();
        }
    }
}
