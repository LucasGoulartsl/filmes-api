﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.data.Dtos;
public class UpdateFilmeDto
{
    [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    [StringLength(50, ErrorMessage = "O tamanho do genêro não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
