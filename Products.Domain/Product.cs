using System;
using System.ComponentModel.DataAnnotations;


namespace Products.Domain
{
    public class Product
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Article no")]
        [StringLength(10,ErrorMessage = "Please enter Article no upto 10 digits")]
        [RegularExpression("^[0-9A-Za-z]*$", ErrorMessage = "Please enter AlphNumerical")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please enter Article no")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Article no")]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter AlphNumerical")]
        [Required(ErrorMessage = "Please enter Price")]
        public Nullable<double> Price { get; set; }

        public Nullable<double> ExcludingPrice { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public System.DateTime UpdateDatetime { get; set; }
        public string Category { get; set; }

    }
}
