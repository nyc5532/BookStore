using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Model.Models;
using System.Collections.Generic;
using System;

namespace BookStore.Service
{
    public interface ICategoryService
    {
        Category Add(Category Category);

        void Update(Category Category);

        Category Delete(int id);

        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAll(string keyword);
        IEnumerable<Category> GetAllByParentId(int parentId);

        Category GetById(int id);

        void Save();
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _CategoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository CategoryRepository, IUnitOfWork unitOfWork)
        {
            this._CategoryRepository = CategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Category Add(Category Category)
        {
            return _CategoryRepository.Add(Category);
        }

        public Category Delete(int id)
        {
            return _CategoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _CategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
                return _CategoryRepository.GetAll();

        }

        public IEnumerable<Category> GetAllByParentId(int parentId)
        {
            return _CategoryRepository.GetMulti(x => x.Status && x.ParentId == parentId);
        }

        public Category GetById(int id)
        {
            return _CategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category Category)
        {
            _CategoryRepository.Update(Category);
        }
    }
}