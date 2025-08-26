using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de Logadouro é Obrigatorio.")]
    public string Logadouro { get; set; }

    [Required(ErrorMessage = "O campo de Numero é Obrigatorio.")]
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }
}
