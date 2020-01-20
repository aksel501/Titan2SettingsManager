using System.ComponentModel.DataAnnotations;

namespace Titan2SettingsManager.Models
{
    public class CreateSettingsViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Value { get; set; }

        public Setting Setting { get; set; }
    }
}