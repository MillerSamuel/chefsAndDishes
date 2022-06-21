using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chefsAndDishes.Models;

public class Chef
{
    [Key]
    public int ChefId{get;set;}

    [Required]
    public string FirstName{get;set;}

    [Required]
    public string LastName{get;set;}

    [Required]
    [DataType(DataType.Date)]
    public DateOnly Dob{get;set;}


    public List<Dish>? CreatedDishes {get;set;}

    public DateTime CreatedAt{get;set;}=DateTime.Now;
    public DateTime UpdatedAt{get;set;}=DateTime.Now;
    }