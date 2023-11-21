using System.ComponentModel.DataAnnotations;

namespace Core.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="Telugu language")]
        Telugu=10,
        [Display(Name = "Hindi language")]
        Hindi =11,
        [Display(Name = "English language")]
        English =12,
        [Display(Name = "Chinise language")]
        Chinise =13,
        [Display(Name = "Japanise language")]
        Japanise =14
    }
}
