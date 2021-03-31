namespace VaporStore.Data.Models
{
    public class GameTag
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}

/*•	GameId – integer, Primary Key, foreign key (required)
•	Game – Game
•	TagId – integer, Primary Key, foreign key (required)
•	Tag – Tag
*/
