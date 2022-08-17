using System.ComponentModel.DataAnnotations;

namespace GameSaper.Web3.Models
{
    public class FieldSize
    {
        //Выполнение валидации введённых данных, а именно значение не может быть нулевым
        [Required]
        [Range(5, 15, ErrorMessage = "Минимальное значение 5. Максимальное значение 15.")]
        public int Height { get; set; }

        [Required]
        [Range(5, 15, ErrorMessage = "Минимальное значение 5. Максимальное значение 15.")]
        public int Width { get; set; }
    }
}
