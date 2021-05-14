using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ActivitiesViewModel : BaseViewModel
    {
        public List<ActivityType> ActivityTypes { get; set; }
        public ICommand LinkToActCommand { get; set; }
        public ActivityTypeRepository activityTypeRepository { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public ICollectionView ActivityTypesCollectionView { get; set; }
        private string _activityTypeFilter = string.Empty;
        public string ActivityTypeFilter
        {
            get
            {
                return _activityTypeFilter;
            }
            set
            {
                _activityTypeFilter = value;
                OnPropertyChanged(nameof(ActivityTypeFilter));
                ActivityTypesCollectionView.Refresh();
            }
        }
        public ActivitiesViewModel()
        {
            ActivityTypes = new List<ActivityType>();
            activityTypeRepository = new ActivityTypeRepository();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            GetActivities();
            LinkToActCommand = new LinkToActCommand(this);
            ActivityTypesCollectionView = CollectionViewSource.GetDefaultView(ActivityTypes);
            ActivityTypesCollectionView.Filter = FilterActivities;
        }

        private bool FilterActivities(object obj)
        {
            if (obj is ActivityType type)
            {
                return type.ActivityName.ToUpper().Contains(ActivityTypeFilter.ToUpper());
            }

            return false;
        }

        public void GetActivities()
        {
            ActivityTypes = (List<ActivityType>)activityTypeRepository.List();
        }
    }
}
