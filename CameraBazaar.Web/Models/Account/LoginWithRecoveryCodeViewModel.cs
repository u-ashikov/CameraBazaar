namespace CameraBazaar.Web.Models.Account
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = CameraBazaarConstants.Display.RecoveryCode)]
        public string RecoveryCode { get; set; }
    }
}
