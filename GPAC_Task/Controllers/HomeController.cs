using GPAC_Task.Models;
using GPAC_Task.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GPAC_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(string customerType)
        {
            if (customerType == "Corporate")
            {
                var customers = await _context.CorporateCustomers.ToListAsync();
                return Json(customers);
            }
            else
            {
                var customers = await _context.IndividualCustomers.ToListAsync();
                return Json(customers);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.ProductServices.ToListAsync();
            return Json(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductUnit(int productId)
        {
            var product = await _context.ProductServices.Where(product => product.Id == productId).FirstOrDefaultAsync();
            return Json(product);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMeetingMinutes([FromBody] MeetingPayload meeting)
        {
            try
            {
                if (meeting.meetingMinutesMaster != null)
                {
                    _context.MeetingMinutesMasters.Add(meeting.meetingMinutesMaster);
                    await _context.SaveChangesAsync();

                    if (meeting.meetingMinutesDetail != null)
                    {
                        foreach (var detail in meeting.meetingMinutesDetail)
                        {
                            detail.MeetingMinutesMasterId = meeting.meetingMinutesMaster.Id;
                            _context.MeetingMinutesDetails.Add(detail);
                        }
                        await _context.SaveChangesAsync();
                    }
                    return Json(new { success = true, message = "Meeting Details Successfully Created!" });
                }
                return Json(new { success = false, message = "Meeting Details failed to Create!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Internal Error. Details: {ex}" });
            }
        }
    }
}
