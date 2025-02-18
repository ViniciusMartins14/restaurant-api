using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using restaurant_api.Data;
using restaurant_api.Models;

namespace restaurant_api.Controllers;

[Route("api/pedido")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public IActionResult EfetuarPedido(OrderModel pedido)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        pedido.UserId = userId;
        _context.Orders.Add(pedido);
        _context.SaveChanges();
        return Ok("Pedido realizado!");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult ListarPedidos()
    {
        return Ok(_context.Orders.ToList());
    }

    [HttpGet("meus")]
    [Authorize]
    public IActionResult MeusPedidos()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return Ok(_context.Orders.Where(p => p.UserId == userId).ToList());
    }
}
