using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restaurant_api.Data;
using restaurant_api.Models;

namespace restaurant_api.Controllers;

[Route("api/produto")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CriarProduto(ProductModel produto)
    {
        _context.Products.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(CriarProduto), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult EditarProduto(int id, ProductModel produto)
    {
        if (id != produto.Id) return BadRequest();
        _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
        return CreatedAtAction(nameof(CriarProduto), new { id = produto.Id }, produto);
    }
}
