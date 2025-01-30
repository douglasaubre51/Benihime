using System;
using Benihime.Data.Enum;
using Benihime.Models;

namespace Benihime.ViewModels;

public class ClubViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public Address address { get; set; }
    public ClubCategory clubCategory { get; set; }
}