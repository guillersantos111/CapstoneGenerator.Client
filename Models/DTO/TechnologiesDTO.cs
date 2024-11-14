using CapstoneGenerator.Client.Models.DTO;
using CapstoneGenerator.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGenerator.Client.Models.DTO
{
    public class TechnologiesDTO
    {
        public int TechId { get; set; }
        public string ProgrammingLanguages { get; set; } = "";
        public string Databases { get; set; } = "";
        public string Frameworks { get; set; } = "";

        public ICollection<CapstoneTechnologyDTO> CapstoneTechnologyDTOs { get; set; } = new List <CapstoneTechnologyDTO>();
    }
}
