using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace bileton.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [StringLength(maximumLength:25)]
        public string  UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 25 , MinimumLength =8)]
        [DataType(DataType.Password)]
        public string  Pasword { get; set; }
    }
}
