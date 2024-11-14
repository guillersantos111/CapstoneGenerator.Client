using CapstoneGenerator.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGenerator.Models.DTO
{
    public class CapstoneTechnologyDTO
    {
        public int CapstoneId { get; set; }
        public CapstonesDTO CapstonesDTOs { get; set; }

        public int TechId { get; set; }
    }
}
