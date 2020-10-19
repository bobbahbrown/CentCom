﻿using CentCom.API.Models;
using CentCom.API.Services;
using CentCom.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentCom.API.Controllers
{
    public class ViewerController : Controller
    {
        private readonly ILogger<ViewerController> _logger;
        private readonly IBanService _banService;
        private readonly IBanSourceService _banSourceService;

        public ViewerController(ILogger<ViewerController> logger, IBanService banService, IBanSourceService banSourceService)
        {
            _logger = logger;
            _banService = banService;
            _banSourceService = banSourceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("viewer/search/{key}")]
        public async Task<IActionResult> SearchBans(string key)
        {
            var ckey = KeyUtilities.GetCanonicalKey(key);
            if (string.IsNullOrWhiteSpace(ckey) || ckey.Length < 3)
            {
                return View("badsearch", new BanSearchViewModel() { CKey = ckey });
            }

            var searchResults = await _banService.SearchSummariesForKeyAsync(key);

            // If there is only one result, just view it
            if (searchResults.Count() == 1)
            {
                return RedirectToAction("ViewBans", new { key = searchResults.First().CKey });
            }

            return View(new BanSearchViewModel() { CKey = ckey, Data = searchResults });
        }

        [HttpGet("viewer/view/{key}")]
        public async Task<IActionResult> ViewBans(string key)
        {
            var bans = await _banService.GetBansForKeyAsync(key, null);

            return View(new BanViewViewModel() { CKey = KeyUtilities.GetCanonicalKey(key), Bans = bans });
        }
    }
}