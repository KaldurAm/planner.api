using System;
using System.Collections;
using System.Collections.Generic;

namespace Planner.Shared.Models
{
    public class ObjectDTO
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CadastralNumber { get; set; }

        public double Area { get; set; }

        public int PropertyId { get; set; }

        public decimal Cost { get; set; }

        public int CurrencyId { get; set; }

        public int ObjectStatusId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DistrictId { get; set; }

        public string Address { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public bool Deleted { get; set; }
    }
}