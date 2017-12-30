using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrCoreDemoWithSqlTableDependency.Models
{
    [Table("GaugesData")]
    public class Gauge
    {
        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }

        [JsonProperty("memory")]
        public int Memory { get; set; }

        [JsonProperty("cpu")]
        public int Cpu { get; set; }

        [JsonProperty("network")]
        public int Network { get; set; }
    }
}
