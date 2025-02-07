using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactsController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactService.GetAllContactAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _ContactService.GetByIdContactAsync(id);
            if (values == null)
            {
                return NotFound(); // HTTP 404 Not Found if no Contact found
            }
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _ContactService.CreateContactAsync(createContactDto);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            var existingContact = await _ContactService.GetByIdContactAsync(id);
            if (existingContact == null)
            {
                return NotFound(); // HTTP 404 Not Found if the Contact doesn't exist
            }

            await _ContactService.DeleteContactAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var existingContact = await _ContactService.GetByIdContactAsync(updateContactDto.ContactId);
            if (existingContact == null)
            {
                return NotFound(); // HTTP 404 Not Found if the Contact doesn't exist
            }

            await _ContactService.UpdateContactAsync(updateContactDto);
            return NoContent(); // HTTP 204 No Content after successful update (no content to return)
        }
    }
}
