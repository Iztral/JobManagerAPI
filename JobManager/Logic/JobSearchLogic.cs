using JobManager.Context;
using JobManager.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManager.Models
{
    public class JobSearchLogic
    {
        private readonly JobContext context;

        public JobSearchLogic(JobContext context)
        {
            this.context = context;
        }

        public IQueryable<Job> GetJobsBySearch(JobSearchModel searchModel)
        {
            IQueryable<Job> data = context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.Title) && !string.IsNullOrEmpty(searchModel.Description))
            {
                return data.Where(x => x.Title.Contains(searchModel.Title) && x.Description.Contains(searchModel.Title));
            }
            if (string.IsNullOrEmpty(searchModel.Title) && !string.IsNullOrEmpty(searchModel.Description))
            {
                return data.Where(x => x.Description.Contains(searchModel.Description));
            }
            if (!string.IsNullOrEmpty(searchModel.Title) && string.IsNullOrEmpty(searchModel.Description))
            {
                return data.Where(x => x.Title.Contains(searchModel.Title));
            }

            return data;
        }
    }
}
