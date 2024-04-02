using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Tokens Available must be a non-negative number.")]
        public int Tokens_Available { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Books Borrowed must be a non-negative number.")]
        public int Books_Borrowed   { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Books Lent must be a non-negative number.")]
        public int Books_Lent { get; set; }

        public string Token { get; set; }

    }
}
