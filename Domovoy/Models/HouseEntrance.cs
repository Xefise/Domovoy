﻿namespace Domovoy.Models;

public class HouseEntrance
{
    public int Id { get; set; }
    
    public int EnranceNumber { get; set; }
    
    public ApartmentHouse ApartmentHouse { get; set; }
    public List<Apartment> Apartments { get; set; }
}