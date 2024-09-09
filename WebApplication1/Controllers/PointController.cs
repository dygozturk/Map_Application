using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Point>>>> GetAll()
        {
            var points = await _unitOfWork.Points.GetAllAsync();
            var pointList = points.ToList(); // Convert IEnumerable to List
            return Ok(new Response<List<Point>>(true, "Success", pointList));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Point>>> GetById(long id)
        {
            var point = await _unitOfWork.Points.GetByIdAsync(id);
            if (point == null)
            {
                return NotFound(new Response<Point>(false, "Point not found", null));
            }
            return Ok(new Response<Point>(true, "Success", point));
        }

        [HttpPost]
        public async Task<ActionResult<Response<Point>>> Add(Point point)
        {
            await _unitOfWork.Points.AddAsync(point);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { id = point.Id }, new Response<Point>(true, "Point added successfully", point));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Point>>> Update(long id, Point updatedPoint)
        {
            var existingPoint = await _unitOfWork.Points.GetByIdAsync(id);
            if (existingPoint == null)
            {
                return NotFound(new Response<Point>(false, "Point not found", null));
            }

            existingPoint.PointX = updatedPoint.PointX;
            existingPoint.PointY = updatedPoint.PointY;
            existingPoint.Name = updatedPoint.Name;

            await _unitOfWork.Points.UpdateAsync(existingPoint);
            await _unitOfWork.CompleteAsync();

            return Ok(new Response<Point>(true, "Point updated successfully", existingPoint));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Delete(long id)
        {
            var existingPoint = await _unitOfWork.Points.GetByIdAsync(id);
            if (existingPoint == null)
            {
                return NotFound(new Response<bool>(false, "Point not found", false));
            }

            await _unitOfWork.Points.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return Ok(new Response<bool>(true, "Point deleted successfully", true));
        }
    }
}
