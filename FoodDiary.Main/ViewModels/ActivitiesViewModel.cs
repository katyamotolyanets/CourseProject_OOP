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
        public string Time { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }
        public LinkToActCommand LinkToActCommand { get; set; }
        public ActivityTypeRepository activityTypeRepository { get; set; }
        public ICollectionView ActivityTypesCollectionView { get; set; }

        private string _activityTypeFilter = string.Empty;
        public UserHistory history { get; set; }

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
        private Activity _activity { get; set; }
        public Activity Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                OnPropertyChanged(nameof(Activity));
            }
        }
        private ActivityType _activityType { get; set; }
        public ActivityType ActivityType
        {
            get { return _activityType; }
            set
            {
                _activityType = value;
                OnPropertyChanged(nameof(ActivityType));
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public bool CanSave => Activity.ActivityTime != 0;
        public ActivitiesViewModel()
        {
            ErrorMessageViewModel = new MessageViewModel();
            Activity = new Activity();
            
            ActivityTypes = new List<ActivityType>();
            activityTypeRepository = new ActivityTypeRepository();
            GetActivities();
            ActivityType = new ActivityType();
            LinkToActCommand = new LinkToActCommand();

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
