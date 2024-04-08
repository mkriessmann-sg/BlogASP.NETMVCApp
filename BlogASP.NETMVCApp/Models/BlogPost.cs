using System.ComponentModel.DataAnnotations;

namespace BlogASP.NETMVCApp.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }    
        public string? Content { get; set; }
        public DateOnly PostDate { get; set; }
    }
}
