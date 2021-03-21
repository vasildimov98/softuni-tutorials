namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        private const int ROOM_CAPACITY = 20;

        private List<Room> rooms;
        private Department()
        {
            this.rooms = new List<Room>();
            InitializeRooms();
        }
        public Department(string name)
            : this ()
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Room LookForFreeSpace()
        {
            return this.rooms
                .FirstOrDefault(r => r.Count < 3);
        }

        public void ReportAll()
        {
            var allFullRooms = this.rooms
                .Where(r => r.Count > 0)
                .ToArray();

            foreach (var room in rooms)
            {
                room.ShowPatient();
            }
        }

        public void ReportOneRoom(int numberOfRoom)
        {
            var room = this.rooms
                .FirstOrDefault(r => r.Number == numberOfRoom);

            if (room.Count > 0)
            {
                room.ShowOrderedPatient();
            }
        }
        private void InitializeRooms()
        {
            for (byte num = 1; num <= ROOM_CAPACITY; num++)
            {
                rooms.Add(new Room(num));
            }
        }

    }
}
