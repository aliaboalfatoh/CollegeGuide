using CollegeGuide.Core.Entities;
using CollegeGuide.Core.Repositories;
using CollegeGuide.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CollegeGuide.Controllers
{
    public class UniversitiesController : APIBaseController
    {
        private readonly IGenericRepoitory<University> _UniversityRepo;

        public UniversitiesController(IGenericRepoitory<University> UniversityRepo)
        {
            _UniversityRepo = UniversityRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversity()
        {
            var Spec = new UniversityWithCollegeandFinancialaids();
            var universities = await _UniversityRepo.GetAllAsync();
            return Ok(universities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversityById(int id)
        {
            var University = await _UniversityRepo.GetByIdAsync(id);
            return Ok(University);
        }

    }
}