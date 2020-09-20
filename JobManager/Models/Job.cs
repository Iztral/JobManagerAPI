using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobManager.Models
{
    public enum Priority { LOW, MEDIUM, HIGH };

    public class Job
    {
        /// <summary>
        /// Job identity number. 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Job title. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Job description. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Estimated time of job completion. 
        /// </summary>
        public DateTime? EstimatedCompletionDate { get; set; }

        /// <summary>
        /// Status of job completion. 
        /// </summary>
        public bool Completed { get; set; } = false;

        /// <summary>
        /// Job priority in enum. 
        /// </summary>
        public Priority Priority { get; set; } = Priority.MEDIUM;
    }
}
