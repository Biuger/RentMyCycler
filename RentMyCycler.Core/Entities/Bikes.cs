using Tecnm.Ecommerce.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentMyCycler.Core.Entities;

public class Bikes: EntityBase
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Id_BikeCategory { get; set; }
    public string Description { get; set; }
    public string Colour { get; set; }
    public string Condition_bike { get; set; }
    public bool Availability { get; set; }
    public decimal Rental_cost { get; set; }
}