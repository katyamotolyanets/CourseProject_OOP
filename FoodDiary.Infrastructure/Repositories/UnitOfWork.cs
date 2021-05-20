using Microsoft.EntityFrameworkCore;
using FoodDiary.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDiary.Core.RepositoryInterfaces;

namespace FoodDiary.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private FoodDiaryContext _context;
        private IAccountRepository _accountRepository;
        private IHistoryRepository _historyRepository;
        private IActivityRepository _activityRepository;
        private IActivityTypeRepository _activityTypeRepository;
        private IChangeWeightRepository _changeWeightRepository;
        private ILifestyleRepository _lifestyleRepository;
        private IMealTypeRepository _mealTypeRepository;
        private IProductSetProductsRepository _productSetProductsRepository;
        private IProductSetRepository _productSetRepository;
        private IProductsRepository _productsRepository;
        private IUserHistoryProductSetsRepository _userHistoryProductSetsRepository;

        private FoodDiaryContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = new FoodDiaryContext();
            }
        }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                if (_historyRepository == null)
                    _historyRepository = new HistoryRepository();
                return _historyRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository();
                return _accountRepository;
            }
        }
        public IActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                    _activityRepository = new ActivityRepository();
                return _activityRepository;
            }
        }
        public IActivityTypeRepository ActivityTypeRepository
        {
            get
            {
                if (_activityTypeRepository == null)
                    _activityTypeRepository = new ActivityTypeRepository();
                return _activityTypeRepository;
            }
        }
        public IChangeWeightRepository ChangeWeightRepository
        {
            get
            {
                if (_changeWeightRepository == null)
                    _changeWeightRepository = new ChangeWeightRepository();
                return _changeWeightRepository;
            }
        }
        public ILifestyleRepository LifestyleRepository
        {
            get
            {
                if (_lifestyleRepository == null)
                    _lifestyleRepository = new LifestyleRepository();
                return _lifestyleRepository;
            }
        }
        public IMealTypeRepository MealTypesRepository
        {
            get
            {
                if (_mealTypeRepository == null)
                    _mealTypeRepository = new MealTypesRepository();
                return _mealTypeRepository;
            }
        }
        public IProductSetProductsRepository ProductSetProductsRepository
        {
            get
            {
                if (_productSetProductsRepository == null)
                    _productSetProductsRepository = new ProductSetProductsRepository();
                return _productSetProductsRepository;
            }
        }
        public IProductSetRepository ProductSetRepository
        {
            get
            {
                if (_productSetRepository == null)
                    _productSetRepository = new ProductSetRepository();
                return _productSetRepository;
            }
        }
        public IProductsRepository ProductsRepository
        {
            get
            {
                if (_productsRepository == null)
                    _productsRepository = new ProductsRepository();
                return _productsRepository;
            }
        }
        public IUserHistoryProductSetsRepository UserHistoryProductSetsRepository
        {
            get
            {
                if (_userHistoryProductSetsRepository == null)
                    _userHistoryProductSetsRepository = new UserHistoryProductSetsRepository();
                return _userHistoryProductSetsRepository;
            }
        }

        public UnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FoodDiaryContext>();
        }

        public void Commit()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            Context.SaveChanges();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                Context.Dispose();
            }

            _isDisposed = true;
        }
    }
}