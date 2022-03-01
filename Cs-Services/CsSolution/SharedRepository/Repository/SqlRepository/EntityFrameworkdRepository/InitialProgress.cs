using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository.Repository.SqlRepository.EntityFrameworkdRepository
{
    public class InitialProgress
    {
        public int Id { get; set; }
        [Required]
        public int Gold { get; set; }
        [Required]
        public int Silver { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int Experience { get; set; }
    }
}
