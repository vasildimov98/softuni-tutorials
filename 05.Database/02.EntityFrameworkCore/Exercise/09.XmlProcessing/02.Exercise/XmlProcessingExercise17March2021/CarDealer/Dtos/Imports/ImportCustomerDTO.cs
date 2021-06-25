﻿namespace CarDealer.DTOs.Imports
{
    using System;
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Customer))]
    public class ImportCustomerDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
