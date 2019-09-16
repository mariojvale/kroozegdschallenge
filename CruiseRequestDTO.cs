﻿using System;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;

namespace Krooze.EntranceTest.WriteHere.Structure.Model
{
    public class CruiseRequestDTO : IRequest
    {
        public string DeparturePort { get; set; }
        public DateTime DepartureDate { get; set; }
        public int CruiseCompanyCode { get; set; }
    }
}
