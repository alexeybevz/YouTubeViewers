﻿using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels
{
    public class  YouTubeViewerDetailsFormViewModel : ViewModelBase
    {
        private string _userName;
        private bool _isSubscribed;
        private bool _isMember;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public bool IsSubscribed
        {
            get
            {
                return _isSubscribed;
            }
            set
            {
                _isSubscribed = value;
                OnPropertyChanged(nameof(IsSubscribed));
            }
        }

        public bool IsMember
        {
            get
            {
                return _isMember;
            }
            set
            {
                _isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(UserName);

        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
