// // ==========================================================================================================
// // 
// //  File ID: SolarSystemMaker - SolarSystemMaker - StarViewModel.cs 
// // 
// //  Last Changed By: ForestFeather - 
// //  Last Changed Date: 7:30 PM, 23/03/2016
// //  Created Date: 5:54 PM, 11/02/2015
// // 
// //  Notes:
// //  
// // ==========================================================================================================

#region Imported Namespaces

#endregion

using SolarSystemLibrary;
using SolarSystemLibrary.Models;

namespace SolarSystemMaker.ViewModels {

    #region Imported Namespaces

    #endregion

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Star view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel<SolarSystemLibrary.Models.IStar>"/>
    /// <seealso cref="SolarSystemLibrary.Models.IStar"/>
    ///-------------------------------------------------------------------------------------------------
    public class StarViewModel : BaseViewModel, IBaseViewModel<IStar>, IStar {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 1/29/2015. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public StarViewModel( ) {
            this.DisplayName = "S:";
            this.PropertyChanged += ( sender, args ) =>
                                    {
                                        switch( args.PropertyName ) {
                                            case "Category":
                                            case "MainSequenceStar":
                                                this.SetDisplayName( );
                                                break;
                                        }
                                    };
        }

        #region Implementation of IBaseViewModel<IStar>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///-------------------------------------------------------------------------------------------------
        public IStar DomainObject {
            get { return this._domainObject; }
            set {
                this._domainObject = value;
                this.SetDisplayName( );
            }
        }

        /// <summary>   The domain object. </summary>
        private IStar _domainObject;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sets display name. </summary>
        ///
        /// <remarks>   Forest Feather, 3/23/2016. </remarks>
        ///-------------------------------------------------------------------------------------------------
        private void SetDisplayName( ) {
            this.DisplayName = string.Format( "S:{0}{1}", this.Category, this.MainSequenceStar ? "*" : "" );
        }

        #endregion

        #region Implementation of IStar

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <value> The category. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.Category"/>
        ///-------------------------------------------------------------------------------------------------
        public StarCategory Category {
            get { return this.DomainObject.Category; }
            set {
                this.DomainObject.Category = value;
                this.OnPropertyChanged( "Category" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a value indicating whether the main sequence star. </summary>
        ///
        /// <value> true if main sequence star, false if not. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.MainSequenceStar"/>
        ///-------------------------------------------------------------------------------------------------
        public bool MainSequenceStar {
            get { return this.DomainObject.MainSequenceStar; }
            set {
                this.DomainObject.MainSequenceStar = value;
                this.OnPropertyChanged( "MainSequenceStar" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the solar mass. </summary>
        ///
        /// <value> The solar mass. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IStar.SolarMass"/>
        ///-------------------------------------------------------------------------------------------------
        public double SolarMass {
            get { return this.DomainObject.SolarMass; }
            set {
                this.DomainObject.SolarMass = value;
                this.OnPropertyChanged( "SolarMass" );
            }
        }

        public IConstruct Construct { get => DomainObject.Construct; set { DomainObject.Construct = value; this.OnPropertyChanged("Construct"); } }

        #endregion
    }
}
