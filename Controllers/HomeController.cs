using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdminTereeViewMenu.Models;

namespace AdminTereeViewMenu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(CreateBaseCategories());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Category CreateBaseCategories()
        {
            Category baseCategory = new Category
            {
                Name = "Base",
                Base = true,
                ChildCategories = new List<Category>
                {
                    new Category
                    {
                        Name = "Главная",
                        ChildCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Все товары"
                            },
                            new Category
                            {
                                Name = "Самые дорогие"
                            },
                            new Category
                            {
                                Name = "Самые дешевые"
                            }
                        }
                    },
                    new Category
                    {
                        Name = "Склад",
                        ChildCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Все товары"
                            }
                        }
                    },
                    new Category
                    {
                        Name = "Витрина",
                        ChildCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Все товары"
                            }
                        }
                    }
                }
            };
            return baseCategory;
        }

    }
}
