using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CT.Api.Models
{
    public class DistanceInputModel
    {

        [Required]
        [MinLength(3)]
        public string SourceCode { get; set; }

        [Required]
        [MinLength(3)]
        public string TargetCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,Formatting.None);
        }

    }
}
