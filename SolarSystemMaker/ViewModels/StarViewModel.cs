// ==========================================================================================================
//  
//   File ID: SolarSystemMaker - SolarSystemMaker - StarViewModel.cs 
//  
//   Copyright 2011-2013
//   WR Medical Electronics Company
//  
//   Last Changed By: cdo - Collin D. O'Connor
//   Last Changed Date: 3:28 PM, 29/01/2015
//   Created Date: 1:11 PM, 19/04/2013
//  
//   Notes:
//   
// ==========================================================================================================

#region Imported Namespaces



#endregion

namespace SolarSystemMaker.ViewModels {
    #region Imported Namespaces

    using SolarSystemLibrary;
    using SolarSystemLibrary.Models;

    #endregion

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
        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 1/29/2015. </remarks>
        ///=================================================================================================
        public StarViewModel( ) {
            this.DisplayName = "S:";
            this.PropertyChanged += ( sender, args ) =>
            {
                switch ( args.PropertyName ) {
                    case "Category":
                    case "MainSequenceStar":
                        this.DisplayName = string.Join( "S:{0}{1}", this.Category, this.MainSequenceStar ? "*" : "" );
                        break;
                }
            };
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
        /// <value> The category. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.Category"/>
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
        /// <value> true if main sequence star, false if not. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.MainSequenceStar"/>
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
        /// <value> The solar mass. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.SolarMass"/>
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
