namespace JSONDemo
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Xml;

    class StarWars
    {
        public List<Person> People { get; set; }
    }

    class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
    }

    class Program
    {
        static void Main()
        {
            string xml = @"<?xml version='1.0' standalone='no'?> 
                                 <root> 
                                    <person id='1'> 
                                        <name>Alan</name> 
                                        <url>www.google.com</url> 
                                    </person> 
                                    <person id='2'> 
                                        <name>Louis</name> 
                                        <url>www.yahoo.com</url> 
                                    </person> 
                                </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(jsonText);

        }
    }
}
