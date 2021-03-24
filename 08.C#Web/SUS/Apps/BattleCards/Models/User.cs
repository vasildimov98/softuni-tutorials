namespace BattleCards.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SUS.MVC;

    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}
