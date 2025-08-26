using System.ComponentModel.DataAnnotations;

namespace FilmesApi.data.Dtos;
public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "O campo de Logadouro é Obrigatorio.")]
    public string Logadouro { get; set; }

    [Required(ErrorMessage = "O campo de Numero é Obrigatorio.")]
    public int Numero { get; set; }
}
