namespace BattleCards.ViewModels.User
{
    using System;

    public class UserViewModel
    {
        public string Day => DateTime.UtcNow.DayOfWeek.ToString();

        public string Message { get; set; }
    }
}
