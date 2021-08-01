namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public int DisplayOrder { get; set; }

        public string Link { get; set; }

        public bool? Status { get; set; }
    }
}