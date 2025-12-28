using System.ComponentModel.DataAnnotations;

namespace AspSampleChangeLanguage.Models
{
    public class FeedbackViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Feedback")]
        public string Feedback { get; set; } = string.Empty;
    }
}
