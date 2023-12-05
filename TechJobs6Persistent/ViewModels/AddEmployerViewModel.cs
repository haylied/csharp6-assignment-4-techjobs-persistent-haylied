using System;
using System.ComponentModel.DataAnnotations;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
	public class AddEmployerViewModel
	{
        [Required(ErrorMessage = "Name is required.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Name needs to be between 3 - 50 characters in length.")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Location needs to be between 3 - 500 characters in length.")]
        public string Location { get; set; }

		public List<Employer> Employers { get; set; }


        public AddEmployerViewModel(List<Employer> employers)
        {
			Employers = employers;
        }

        //      public AddEmployerViewModel(string name, string location)
        //{
        //	Name = name;
        //	Location = location;
        //}

        public AddEmployerViewModel()
        {
         
        }
    }

}

