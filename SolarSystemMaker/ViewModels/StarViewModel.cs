// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - StarViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 10:44 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemMaker.ViewModels {
    ///=================================================================================================
    /// <summary>   Star view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel<SolarSystemLibrary.Models.IStar>"/>
    /// <seealso cref="SolarSystemLibrary.Models.IStar"/>
    ///=================================================================================================
    public class StarViewModel : BaseViewModel, IBaseViewModel<IStar>, IStar {

        public StarViewModel( ) {
            DisplayName = "Star";
        }

        #region Implementation of IBaseViewModel<IStar>

        ///=================================================================================================
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///=================================================================================================
        public IStar DomainObject { get; set; }

        #endregion

        #region Implementation of IStar

        ///=================================================================================================
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.Category"/>
        ///
        /// ### <value> The category. </value>
        ///=================================================================================================
        public StarCategory Category {
            get { return this.DomainObject.Category; }
            set {
                this.DomainObject.Category = value;
                this.OnPropertyChanged( "Category" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the main sequence star. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.MainSequenceStar"/>
        ///
        /// ### <value> true if main sequence star, false if not. </value>
        ///=================================================================================================
        public bool MainSequenceStar {
            get { return this.DomainObject.MainSequenceStar; }
            set {
                this.DomainObject.MainSequenceStar = value;
                this.OnPropertyChanged( "MainSequenceStar" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the solar mass. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.SolarMass"/>
        ///
        /// ### <value> The solar mass. </value>
        ///=================================================================================================
        public double SolarMass {
            get { return this.DomainObject.SolarMass; }
            set {
                this.DomainObject.SolarMass = value;
                this.OnPropertyChanged( "SolarMass" );
            }
        }

        #endregion
    }
}
