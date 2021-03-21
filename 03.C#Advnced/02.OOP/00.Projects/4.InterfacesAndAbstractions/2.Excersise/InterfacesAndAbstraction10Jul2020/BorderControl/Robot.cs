﻿namespace BorderControl
{
    public class Robot : IIdentifiable, IRobot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }

        public string Id { get; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
