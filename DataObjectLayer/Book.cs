using System.ComponentModel.DataAnnotations;

namespace DataObjectLayer
{
    public class Book
    {
        
        [Key]
        public int bookId { get; set; }

        [Required(ErrorMessage = "The Book Name is required.")]
        public string Book_Name { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "The Author Name is required.")]
        public string Author_Name { get; set; }
        [Required(ErrorMessage = "The genre is required.")]
        public string genre { get; set; }
        [Display(Name = "Is Book Available")]
        public Boolean Is_Book_Available { get; set; }
        [StringLength(500, ErrorMessage = "The Description cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Display(Name = "Lent By User ID")]
        public int Lent_By_User_id { get; set; }
        [Display(Name = "Currently Borrowed By User ID")]
        public int Currently_Borrowed_By_User_Id { get; set; }

    }
}