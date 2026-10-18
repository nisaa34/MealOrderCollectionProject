 using System.ComponentModel.DataAnnotations;

public class MealOrder
{
    public string OrderID { get; set; }

    [Required(ErrorMessage = "Please enter student name.")]
    public string StudentName { get; set; }

    [Required(ErrorMessage = "Please enter meal name.")]
    public string MealName { get; set; }

    public bool Collected { get; set; }

    public DateTime? CollectedAt { get; set; }
}