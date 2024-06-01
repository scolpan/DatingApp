﻿using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers() 
    {
        var users = await _userRepository.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{username}")] // /api/users/lisa
    public async Task<ActionResult<MemberDTO>> GetUser(string username) 
    {
        return await _userRepository.GetMemberAsync(username);
         
    }


    // [HttpGet("claim")]
    // public ActionResult GetClaim() {

    //     var user = User;
    //     //var role = user

    //     return Ok(user.Claims.First().Value);
    // }

}
