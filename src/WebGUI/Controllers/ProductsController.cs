// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestVladiola.Application.Common.Models;
using RestVladiola.Application.Products.Commands.CreateProduct;
using RestVladiola.Application.Products.Commands.UpdateProduct;
using RestVladiola.Application.Products.Queries.GetProductsWithPagination;

namespace RestVladiola.WebGUI.Controllers;

[Authorize]
public class ProductsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductBriefItem>>> GetProductsWithPagination(
        [FromQuery] GetProductsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateProduct(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}