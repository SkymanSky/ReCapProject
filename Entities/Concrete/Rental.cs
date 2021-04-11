﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental:IEntity
    { 
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
