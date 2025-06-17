using System.ComponentModel.DataAnnotations;

namespace DotNetGRPC.Common.Dtos;

public class CreateSupplierDto
{
    [Required]
    public string Name { get; set; } = "";
}
