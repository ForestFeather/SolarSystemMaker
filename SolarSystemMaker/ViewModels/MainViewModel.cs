// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - MainViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 8:56 AM, 02/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.ObjectModel;

#endregion

namespace SolarSystemMaker.ViewModels {
    ///=================================================================================================
    /// <summary>   Main view model. </summary>
    ///
    /// <remarks>   Cdo, 4/2/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    ///=================================================================================================
    public class MainViewModel : BaseViewModel {
        /// <summary>   The selected view model. </summary>
        private IBaseViewModel _selectedViewModel;

        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 4/2/2013. </remarks>
        ///=================================================================================================
        public MainViewModel( ) {
            this.ViewModels = new ObservableCollection<IBaseViewModel>( );
        }

        #endregion

        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the view models. </summary>
        ///
        /// <value> The view models. </value>
        ///=================================================================================================
        public ObservableCollection<IBaseViewModel> ViewModels { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the selected view model. </summary>
        ///
        /// <value> The selected view model. </value>
        ///=================================================================================================
        public IBaseViewModel SelectedViewModel {
            get { return this._selectedViewModel; }
            set {
                this._selectedViewModel = value;
                this.OnPropertyChanged( "SelectedViewModel" );
            }
        }

        #endregion
    }
}
