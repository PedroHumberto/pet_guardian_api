﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetGuadian.Application.Dto;
using PetGuadian.Application.Interfaces;


namespace PetGuadian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost("createPet")]
        public async Task<IActionResult> CreatePet(PetDto petDto)
        {
            await _petService.CreatePet(petDto);

            return Created("Success", petDto);
        }

        [HttpGet("getPetByUserId")]
        public async Task<IActionResult> GetPetByUserId(Guid userId)
        {
            var pets = await _petService.GetAllPetsByUserId(userId);

            if (pets.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(pets);
        }

    }
}
