// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

namespace RestVladiola.Application.Common.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Phone { get; set; }
    public string? HouseNum { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? Nickname { get; set; }
    public string? CompanyName { get; set; }
    public string Password { get; set; }
}