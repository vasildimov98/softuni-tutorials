namespace XmlDemo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class JediMaster
    {
        public string Name { get; set; }

        [XmlIgnore]
        public string LightsaberColor { get; set; }
    }

    [XmlRoot("something")]
    public class Apprentice
    {
        public string Name { get; set; }

        public JediMaster JediMaster { get; set; }

        [XmlIgnore()]
        public string LightsaberColor { get; set; }

    }

    public class Program
    {
        static void Main()
        {
            var jedi = new JediMaster
            {
                Name = "Obi-Wan Kenobi",
                LightsaberColor = "Blue"
            };

            var apprentice = new Apprentice
            {
                Name = "Anakin Skywaker",
                JediMaster = jedi,
                LightsaberColor = "Blue"
            };

            var serializer = new XmlSerializer(typeof(Apprentice));

            using (var streamWriter = new StreamWriter("myAppretince.xml"))
            {
                serializer.Serialize(streamWriter, apprentice);
            }

            var desirializeAppretince = (Apprentice)serializer.Deserialize(new StreamReader("myAppretince.xml"));

            Console.WriteLine(desirializeAppretince.Name);
            Console.WriteLine(desirializeAppretince.JediMaster.Name);
            Console.WriteLine(desirializeAppretince.LightsaberColor);
        }
    }
}
