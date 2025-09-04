using System.ComponentModel.DataAnnotations;

namespace MyLearningProject.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}