using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Titan2SettingsManager.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Value { get; set; }

        public class SettingsDBContext : DbContext
        {
            public SettingsDBContext() : base("SettingsDBContext")
            {
            }

            public static SettingsDBContext Create()
            {
                return new SettingsDBContext();
            }

            public DbSet<Setting> Settings { get; set; }
        }
    }
}