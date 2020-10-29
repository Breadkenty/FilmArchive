using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmArchive.Domain.Models;
using FilmArchive.Persistence.Context;
using MediatR;
using FilmArchive.Application.CQRS.Entries.GetEntries;
using FilmArchive.Application.CQRS.Entries.GetEntry;
using Microsoft.Extensions.Configuration;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace FilmArchive.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string CLOUDINARY_CLOUD_NAME;
        private readonly string CLOUDINARY_API_KEY;
        private readonly string CLOUDINARY_API_SECRET;

        public UploadsController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            CLOUDINARY_CLOUD_NAME = config["CLOUDINARY_CLOUD_NAME"];
            CLOUDINARY_API_KEY = config["CLOUDINARY_API_KEY"];
            CLOUDINARY_API_SECRET = config["CLOUDINARY_API_SECRET"];
        }

        private readonly HashSet<string> VALID_CONTENT_TYPES = new HashSet<string> {
            "image/jpg",
            "image/jpeg",
            "image/pjpeg",
            "image/gif",
            "image/x-png",
            "image/png",
        };

        // GET: api/Entries
        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public async Task<ActionResult<IEnumerable<GetEntriesResponse>>> Upload(IFormFile file)
        {
            var contentType = file.ContentType.ToLower();
            if (!VALID_CONTENT_TYPES.Contains(contentType))
            {
                return BadRequest("Not Valid Image");
            }

            var cloudinaryClient = new Cloudinary(new Account(CLOUDINARY_CLOUD_NAME, CLOUDINARY_API_KEY, CLOUDINARY_API_SECRET));

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            ImageUploadResult result = await cloudinaryClient.UploadLargeAsync(uploadParams);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var urlOfUploadedFile = result.SecureUrl.AbsoluteUri;
                return Ok(new { url = urlOfUploadedFile });
            }
            else
            {
                return BadRequest("Upload failed");
            }
        }

    }
}
