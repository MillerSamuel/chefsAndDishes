using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chefsAndDishes.Models;


public class CaloriesValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value==null){
            return ValidationResult.Success;
        }

        if ((int)value < 1)
            return new ValidationResult("Calories must be over 0");
        return ValidationResult.Success;
    }
}
public class Dish
{
    [Key]
    public int DishId{get;set;}

    [Required]
    public string Name{get;set;}

    [Required]
    [CaloriesValidation]
    public int Calories{get;set;}

    [Required]
    public string Description{get;set;}

    [Required]
    public int Tastiness {get;set;}

    [Required]
    public int ChefId {get;set;}

    public Chef? Chef{get;set;}

    public DateTime CreatedAt{get;set;}=DateTime.Now;
    public DateTime UpdatedAt{get;set;}=DateTime.Now;

}
