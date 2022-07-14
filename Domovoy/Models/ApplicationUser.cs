﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domovoy.Models;

public class ApplicationUser : IdentityUser<int>
{
    [Required]
    public ApplicationUserType Type { get; set; }
    
    /// <summary>
    /// If Tenant
    /// Apartments where user living
    /// </summary>
    public List<Apartment> Apartments { get; set; }
    /// <summary>
    /// If Tenant
    /// Apartments that user owns
    /// </summary>
    public List<Apartment> OwndedApartments { get; set; }
    /// <summary>
    /// If Tenant
    /// </summary>
    public Apartment? MainApartment { get; set; }
    
    /// <summary>
    /// If ConstructionCompanyAdmin
    /// </summary>
    public ConstructionCompany? ConstructionCompany { get; set; }
}

public enum ApplicationUserType
{
    Tenant,
    ConstructionCompanyAdmin,
    ServiceProvider
}