using AutoMapper;
using BookStore.Model.Models;
using BookStore.Service;
using BookStore.Web.Infrastructure.Core;
using BookStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Web.Infrastructure.Extensions;

namespace BookStore.Web.Api
{
    [RoutePrefix("api/category")]
    [Authorize]
    public class CategoryController : ApiControllerBase
    {
        #region Initialize
        private ICategoryService _categoryService;

        public CategoryController(IErrorService errorService, ICategoryService categoryService)
            : base(errorService)
        {
            this._categoryService = categoryService;
        }
        #endregion
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                
                var model = _categoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(model);
                var reponse = request.CreateResponse(HttpStatusCode.OK, responseData);
                return reponse;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var model = _categoryService.GetById(id);
                var responseData = Mapper.Map<Category,CategoryViewModel>(model);
                var reponse = request.CreateResponse(HttpStatusCode.OK, responseData);
                return reponse;
            });
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _categoryService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(query);
                var paginationSet = new PaginationSet<CategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var reponse = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return reponse;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CategoryViewModel categoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newCategory = new Category();
                    newCategory.UpdateCategory(categoryVm);
                    newCategory.CreatedDate = DateTime.Now;
                    _categoryService.Add(newCategory);
                    _categoryService.Save();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(newCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                

                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CategoryViewModel categoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbCategory = _categoryService.GetById(categoryVm.Id);
                    dbCategory.UpdateCategory(categoryVm);
                    dbCategory.UpdatedDate = DateTime.Now;
                    _categoryService.Update(dbCategory);
                    _categoryService.Save();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(dbCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }


                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldCategory = _categoryService.Delete(id);
                    _categoryService.Save();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(oldCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }


                return response;
            });
        }

    }
}