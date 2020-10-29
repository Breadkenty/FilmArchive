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

        // POST: api/Uploads
        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public async System.Threading.Tasks.Task<ActionResult> UploadAsync(IFormFile file)
        {
            // Check this content type against a set of allowed content types
            var contentType = file.ContentType.ToLower();
            if (!VALID_CONTENT_TYPES.Contains(contentType))
            {
                // Return a 400 Bad Request when the content type is not allowed
                return BadRequest("Not Valid Image");
            }

            // Create and configure a client object to be able to upload to Cloudinary
            var cloudinaryClient = new Cloudinary(new Account(CLOUDINARY_CLOUD_NAME, CLOUDINARY_API_KEY, CLOUDINARY_API_SECRET));

            // Create an object describing the upload we are going to process.
            // We will provide the file name and the stream of the content itself.
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            // Upload the file to the server
            ImageUploadResult result = await cloudinaryClient.UploadLargeAsync(uploadParams);

            // If the status code is a "OK" then the upload was accepted so we will return
            // the URL to the client
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var urlOfUploadedFile = result.SecureUrl.AbsoluteUri;

                return Ok(new { url = urlOfUploadedFile });
            }
            else
            {
                // Otherwise there was some failure in uploading
                return BadRequest("Upload failed");
            }
        }

    }
}
