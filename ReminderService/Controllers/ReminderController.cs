using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/reminder")] // Base route for ReminderController
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public IActionResult CreateReminder(Reminder reminder)
        {
            // Call the ReminderService to create a reminder
            var createdReminder = _reminderService.CreateReminder(reminder);
            return Created("", createdReminder); // 201 Created
        }

        [HttpDelete("{reminderId}")]
        public IActionResult DeleteReminder(int reminderId)
        {
            // Call the ReminderService to delete a reminder
            var result = _reminderService.DeletReminder(reminderId);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpPut("{reminderId}")]
        public IActionResult UpdateReminder(int reminderId, Reminder reminder)
        {
            // Call the ReminderService to update a reminder
            var result = _reminderService.UpdateReminder(reminderId, reminder);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        //[HttpGet("{userId}")]
        //public IActionResult GetRemindersByUserId(string userId)
        //{
        //    // Call the ReminderService to get reminders by user ID
        //    var reminders = _reminderService.GetAllRemindersByUserId(userId);
        //    return Ok(reminders); // 200 OK
        //}

        [HttpGet("{reminderId}")]
        public IActionResult GetReminderById(int reminderId)
        {
            // Call the ReminderService to get a reminder by ID
            var reminder = _reminderService.GetReminderById(reminderId);
            if (reminder != null)
            {
                return Ok(reminder); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }
    }
}
