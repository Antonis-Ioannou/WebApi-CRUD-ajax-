using Project.Entities.Custom_validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Product
    {
        //Properties and validations
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        [MaxLength(60, ErrorMessage = "Title must be less than 60 characters")]
        [MinLength(3, ErrorMessage = "Title must be greater than 3 characters")]
        public string Name { get; set; }
        [CustomValidation(typeof(ValidationMethods), Methods.ValidateGreaterThanZero)]
        public double Price { get; set; }

        //constructors
        public Product()
        {

        }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

    }
}
