namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private List<Cash> cash;
        private List<Gem> gems;
        private List<Gold> gold;
        private Bag()
        {
            this.cash = new List<Cash>();
            this.gems = new List<Gem>();
            this.gold = new List<Gold>();
        }

        public Bag(long capacity)
            : this()
        {
            this.Capacity = capacity;
        }
        public long Capacity { get; set; }

        public void AddCash(Cash cash)
        {
            if (this.Capacity - cash.Amount >= 0 && SimiliarCash(cash))
            {
                this.cash.Add(cash);
                this.Capacity -= cash.Amount;
            }
        }

        public long CurrentCashAmount()
        {
            var sum = 0L;

            foreach (var cash in this.cash)
            {
                sum += cash.Amount;
            }

            return sum;
        }

        public void AddGem(Gem gem)
        {
            if (this.Capacity - gem.Amount >= 0 && SimiliarGem(gem))
            {
                this.gems.Add(gem);
                this.Capacity -= gem.Amount;
            }
        }

        public long CurrentGemAmount()
        {
            var sum = 0L;

            foreach (var gem in this.gems)
            {
                sum += gem.Amount;
            }

            return sum;
        }
        public void AddGold(Gold gold)
        {
            if (this.Capacity - gold.Amount >= 0 && SimiliarGold(gold))
            {
                this.gold.Add(gold);
                this.Capacity -= gold.Amount;
            }
        }

        public long CurrentGoldAmount()
        {
            return this.gold.Select(g => g.Amount).Sum();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.gold.Count > 0)
            {
                sb.AppendLine($"<Gold> ${this.CurrentGoldAmount()}");

                foreach (var gold in this.gold
                   .OrderByDescending(gld => gld.Name)
                   .ThenBy(gld => gld.Amount))
                {
                    sb.AppendLine($"##{gold.Name} - {gold.Amount}");
                }
            }

            if (this.gems.Count > 0)
            {
                sb.AppendLine($"<Gem> ${this.CurrentGemAmount()}");

                foreach (var gem in this.gems
                    .OrderByDescending(g => g.Name)
                    .ThenBy(g => g.Amount))
                {
                    sb.AppendLine($"##{gem.Name} - {gem.Amount}");
                }
            }

            if (this.cash.Count > 0)
            {
                sb.AppendLine($"<Cash> ${this.CurrentCashAmount()}");

                foreach (var cash in this.cash
                    .OrderByDescending(c => c.Name)
                    .ThenBy(c => c.Amount))
                {
                    sb.AppendLine($"##{cash.Name} - {cash.Amount}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private bool SimiliarCash(Cash cash)
        {
            foreach (var currCash in this.cash)
            {
                if (currCash.CompareTo(cash) == 0)
                {
                    currCash.Amount += cash.Amount;
                    return false;
                }
            }

            return true;
        }
        private bool SimiliarGem(Gem gem)
        {
            foreach (var currGem in this.gems)
            {
                if (currGem.CompareTo(gem) == 0)
                {
                    currGem.Amount += gem.Amount;
                    return false;
                }
            }

            return true;
        }
        private bool SimiliarGold(Gold gold)
        {
            foreach (var currGold in this.gold)
            {
                if (currGold.CompareTo(gold) == 0)
                {
                    currGold.Amount += gold.Amount;
                    return false;
                }
            }

            return true;
        }
    }
}
