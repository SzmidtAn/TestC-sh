using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Entities;

public class BaseEntity
{
    [Key]
    public int ID { get; set; }


}
