using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 

[ApiController]

public class SecondBookController : ControllerBase
{
    //Methode GET
    [HttpGet]
    //Route permet de definir l'url de la methode
    [Route("api/test")]
    public ActionResult<List<Test>> GetBooks()
    {
        var books = new List<Test>
        {
            new() { Id = 1, Title = "Elon Musk", Author = "Elon musk", Price = "10€" },
        };

        return books;
    }

}

