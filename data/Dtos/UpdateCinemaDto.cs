using System.ComponentModel.DataAnnotations;

namespace FilmesApi.data.Dtos;
public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatorio.")]
    public string Nome { get; set; }
}
