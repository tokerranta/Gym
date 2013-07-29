using FysEtt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FysEtt.Controllers
{
    public class NewsDataController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get([FromBody]Pager model)
        {
            var newsItems = from n in _uow.NewsRepository.Items().ToArray()
                            select new
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Text = n.Text,
                                CreatedBy = n.CreatedBy,
                                Created = n.Created.ToString("yyyy-dd-MM")
                            };

            var response = Request.CreateResponse(HttpStatusCode.OK, model, "application/json");
            return response;
            
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = null;
            var newsItem = _uow.NewsRepository.FindById(id);

            if (newsItem == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "No items found");
            }
            else
            {
                var model = new
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Text = newsItem.Text,
                    CreatedBy = newsItem.CreatedBy,
                    Created = newsItem.Created.ToString("yyyy-dd-MM")
                };

                response = Request.CreateResponse(HttpStatusCode.OK, model);
            }

            return response;

        }
    }
}
