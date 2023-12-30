using AutoMapper;
using EventTicket.Services.EventCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventTicket.Services.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.EventDto>>> Get([FromQuery] Guid categoryId)
        {
            var result = await eventRepository.GetEvents(categoryId);
            return Ok(mapper.Map<List<Models.EventDto>>(result));
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Models.EventDto>> GetById(Guid eventId)
        {
            var result = await eventRepository.GetEventById(eventId);
            return Ok(mapper.Map<Models.EventDto>(result));
        }

        [HttpGet("events")]
        public async Task<ActionResult<List<Models.EventDto>>> GetEventsByIds([FromQuery(Name = "eventIds")] string idList)
        {
            List<Guid> eventIds = idList.Split(',').Select(id => Guid.Parse(id)).ToList();
            var events = await eventRepository.GetEventsByIds(eventIds);
            return Ok(mapper.Map<List<Models.EventDto>>(events));
        }

        [HttpGet("eventsFilter")]
        public async Task<ActionResult<List<Models.EventDto>>> GetEventsByIds([FromQuery] Guid categoryId, [FromQuery] string? date, [FromQuery] string? city)
        {
            var result = await eventRepository.GetEvents(categoryId, date, city);
            return Ok(mapper.Map<List<Models.EventDto>>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Models.EventDto>> CreateEvent([FromBody] Models.EventDto eventDto)
        {
            try
            {
                if (eventDto == null)
                {
                    return BadRequest("Invalid event data.");
                }

                var createdEvent = await eventRepository.AddEventAsync(mapper.Map<Entities.Event>(eventDto));

                if (createdEvent == null)
                {
                    return StatusCode(500, "Failed to create the event.");
                }

                var createdEventDto = mapper.Map<Models.EventDto>(createdEvent);
                return CreatedAtAction(nameof(GetById), new { eventId = createdEventDto.EventId }, createdEventDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{eventId}")]
        public async Task<ActionResult> DeleteEvent(Guid eventId)
        {
            try
            {
                var deleted = await eventRepository.DeleteEventAsync(eventId);

                if (!deleted)
                {
                    return NotFound("Event not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}