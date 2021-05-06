using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class DiaryViewModel : BaseViewModel
    {
        public List<MealType> MealTypes { get; set; }
        public MealTypesRepository MealTypeRepository { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public LinkToAddCommand LinkToAddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public LinkToEditCommand LinkToEditCommand { get; set; }
        public ProductSetRepository ProductSetRepository { get; set; }

        private ICollectionView _productSetCollectionView { get; set; }
        public ICollectionView ProductSetCollectionView
        {
            get { return _productSetCollectionView; }
            set
            {
                _productSetCollectionView = value;
                OnPropertyChanged(nameof(ProductSetCollectionView));
            }
        }
        private List<ProductSet> _productSets { get; set; }
        public List<ProductSet> ProductSets
        {
            get { return _productSets; }
            set
            {
                _productSets = value;
                OnPropertyChanged(nameof(ProductSets));
                RefreshProductSetCollectionView();
            }
        }
        private List<ProductSet> _breakfast { get; set; }
        public List<ProductSet> Breakfasts
        {
            get { return _breakfast; }
            set
            {
                _breakfast = value;
                OnPropertyChanged(nameof(Breakfasts));
            }
        }
        private List<ProductSet> _lunch { get; set; }
        public List<ProductSet> Lunches
        {
            get { return _lunch; }
            set
            {
                _lunch = value;
                OnPropertyChanged(nameof(Lunches));
            }
        }
        private List<ProductSet> _dinner { get; set; }
        public List<ProductSet> Dinners
        {
            get { return _dinner; }
            set
            {
                _dinner = value;
                OnPropertyChanged(nameof(Dinners));
            }
        }
        private List<ProductSet> _snack { get; set; }
        public List<ProductSet> Snacks
        {
            get { return _snack; }
            set
            {
                _snack = value;
                OnPropertyChanged(nameof(Snacks));
            }
        }
        public ProductSet ProductSet { get; set; }

        public DiaryViewModel()
        {
            ProductSets = new List<ProductSet>();
            ProductSetRepository = new ProductSetRepository();
            ProductSet = new ProductSet();

            Breakfasts = new List<ProductSet>();
            Lunches = new List<ProductSet>();
            Dinners = new List<ProductSet>();
            Snacks = new List<ProductSet>();

            MealTypes = new List<MealType>();
            MealTypeRepository = new MealTypesRepository();


            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            LinkToAddCommand = new LinkToAddCommand(this);
            LinkToEditCommand = new LinkToEditCommand(this);
            DeleteCommand = new DeleteCommand(this);
            EditCommand = new EditCommand(ProductSet);

            GetSets();
            GetBreakfasts();
            GetLunches();
            GetDinners();
            GetSnacks();
            GetTypes();

        }

        public void GetTypes()
        {
            MealTypes = (List<MealType>)MealTypeRepository.List();
        }

        public void GetSets()
        {
            ProductSets = (List<ProductSet>)ProductSetRepository.List();
        }
        public void GetBreakfasts()
        {
            Breakfasts = (List<ProductSet>)ProductSetRepository.List();
            Breakfasts = ProductSets.Where(x => x.MealType.ID == Guid.Parse("ef1a9d00-2e52-46d3-8e61-6e06553d8e95")).ToList();
        }
        public void GetLunches()
        {
            Lunches = (List<ProductSet>)ProductSetRepository.List();
            Lunches = ProductSets.Where(x => x.MealType.ID == Guid.Parse("eb571bbc-462c-4098-8826-fad31a3cb6d3")).ToList();
        }
        public void GetDinners()
        {
            Dinners = (List<ProductSet>)ProductSetRepository.List();
            Dinners = ProductSets.Where(x => x.MealType.ID == Guid.Parse("e76f357c-b4a0-4f64-a74f-ac0b0f5c815d")).ToList();
        }
        public void GetSnacks()
        {
            Snacks = (List<ProductSet>)ProductSetRepository.List();
            Snacks = Snacks.Where(x => x.MealType.ID == Guid.Parse("000205a2-e914-4469-853e-90eb8b17210d")).ToList();
        }
        public class MealTypeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                MealType mealtype = (MealType)value;

                if (value == null)
                {
                    return mealtype;
                }
                return mealtype;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
        public void RefreshProductSetCollectionView()
        {
            ProductSetCollectionView = CollectionViewSource.GetDefaultView(ProductSets);
            ProductSetCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(ProductSet.MealType), new MealTypeConverter()));
            ProductSetCollectionView.SortDescriptions.Add(new SortDescription("IDType", ListSortDirection.Descending));
            ProductSetCollectionView.Refresh();
        }





        //private RelayCommand showSnack;
        //public RelayCommand ShowSnackCommand
        //{
        //    get
        //    {
        //        return showSnack ?? (showSnack = new RelayCommand(obj =>
        //        {
        //            Snacks = (List<ProductSet>)ProductSetRepository.List();
        //            Snacks = Snacks.Where(x => x.MealType.ID == Guid.Parse("000205a2-e914-4469-853e-90eb8b17210d")).ToList();
        //        }));

        //    }
        //}
    }
}
