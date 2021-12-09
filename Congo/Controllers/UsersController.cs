﻿using Congo.DTOs;
using Congo.Models;
using Congo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        //GET /users
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = (await repository.GetUsersAsync()).Select(user => user.AsDTO());
            return users;
        }

        //GET /users/{id}
        [HttpGet("{id")]
        public async Task<ActionResult<UserDTO>> GetUserAsync(Guid Id)
        {
            var user = await repository.GetUserAsync(Id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user.AsDTO());
        }

        //POST /users/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginUserAsync(LoginUserDTO userDTO)
        {
            var user = await repository.LoginUserAsync(userDTO.Email, userDTO.Password);

            return Ok(user.AsDTO());
        }

        //POST /users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterUserAsync(RegisterUserDTO userDTO)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,
                Role = userDTO.Role
            };

            await repository.RegisterUserAsync(user);

            return CreatedAtAction(nameof(GetUserAsync), new { id = user.Id }, user.AsDTO());
        }

        //PUT /users/{id}
        [HttpPut("{id")]

        public async Task<ActionResult> UpdateUserAsync(Guid id, UpdateUserDTO userDTO)
        {
            var existingUser = await repository.GetUserAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,
                Role = userDTO.Role
            };

            await repository.UpdateUserAsync(updatedUser);

            return NoContent();
        }

        //DELETE /users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            var existingItem = await repository.GetUserAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}