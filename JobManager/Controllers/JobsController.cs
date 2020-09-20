using JobManager.Context;
using JobManager.Extensions;
using JobManager.Filter;
using JobManager.Models;
using JobManager.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobContext context;

        public JobsController(JobContext context)
        {
            this.context = context;
        }

        // GET: api/Jobs/
        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] PaginationFilter paginationFilter)
        {
            PaginationFilter validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            List<Job> jobPage = await context.Jobs
                                    .OrderByDescending(x => x.Priority)
                                    .Paginate(validPaginationFilter)
                                    .ToListAsync();

            return base.Ok(PrepareJobPageResponse(jobPage, validPaginationFilter, await context.Jobs.CountAsync()));
        }

        // GET: api/Jobs/search?title=x&?description=y
        [HttpGet("search")]
        public async Task<IActionResult> SearchJobs([FromQuery] JobSearchModel searchModel, [FromQuery] PaginationFilter paginationFilter)
        {
            PaginationFilter validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            JobSearchLogic searchLogic = new JobSearchLogic(context);
            IQueryable<Job> foundJobs = searchLogic.GetJobsBySearch(searchModel);

            List<Job> jobPage = await foundJobs
                                    .OrderByDescending(x => x.Priority)
                                    .Paginate(validPaginationFilter)
                                    .ToListAsync();

            return base.Ok(PrepareJobPageResponse(jobPage, validPaginationFilter, await foundJobs.CountAsync()));
        }

        // GET: api/Jobs/filter?completed=true
        [HttpGet("filter")]
        public async Task<IActionResult> FilterJobs([FromQuery] bool? completed, [FromQuery] PaginationFilter paginationFilter)
        {
            PaginationFilter validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            IQueryable<Job> filteredJobs = completed != null ? context.Jobs.Where(x => x.Completed == completed) : context.Jobs;

            List<Job> jobPage = await filteredJobs.OrderByDescending(x => x.Priority)
                                    .Paginate(validPaginationFilter)
                                    .ToListAsync();

            return base.Ok(PrepareJobPageResponse(jobPage, validPaginationFilter, await filteredJobs.CountAsync()));
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await context.Jobs.Where(a => a.ID == id).FirstOrDefaultAsync();
            return Ok(new Response<Job>(job));
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.ID)
            {
                return BadRequest();
            }

            context.Entry(job).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Jobs/5/priority?jobPriority=0
        [HttpPut("{id}/priority")]
        public async Task<IActionResult> ChangeJobPriority(int id, Priority jobPriority)
        {
            var job = context.Jobs.SingleOrDefault(x => x.ID == id);

            try
            {
                if (job != null)
                {
                    job.Priority = jobPriority;
                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Jobs/5/completion?true
        [HttpPut("{id}/completed")]
        public async Task<IActionResult> ChangeJobState(int id, bool jobCompleated)
        {
            var job = context.Jobs.SingleOrDefault(x => x.ID == id);

            try
            {
                if (job != null)
                {
                    job.Completed = jobCompleated;
                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<IActionResult> PostJob(Job job)
        {
            context.Jobs.Add(job);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.ID }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(int id)
        {
            var job = await context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            context.Jobs.Remove(job);
            await context.SaveChangesAsync();

            return job;
        }

        private bool JobExists(int id)
        {
            return context.Jobs.Any(e => e.ID == id);
        }

        private PagedResponse<List<Job>> PrepareJobPageResponse(List<Job> jobPage, PaginationFilter paginationFilter, int totalJobs)
        {
            return new PagedResponse<List<Job>>(jobPage, paginationFilter.PageNumber, paginationFilter.PageSize)
            {
                TotalRecords = totalJobs,
                TotalPages = (int)Math.Ceiling(totalJobs / (decimal)paginationFilter.PageSize)
            };
        }
    }
}
