// // ==========================================================================================================
// // 
// //  File ID: SolarSystemMaker - SolarSystemMaker - PlanetViewModel.cs 
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

using System.Collections.Generic;

using SolarSystemLibrary;
using SolarSystemLibrary.Models;

namespace SolarSystemMaker.ViewModels {
    #region Imported Namespaces

    

    #endregion

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Planet view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel<SolarSystemLibrary.Models.IPlanetaryBody>"/>
    /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody"/>
    ///-------------------------------------------------------------------------------------------------
    public class PlanetViewModel : BaseViewModel, IBaseViewModel<IPlanetaryBody>, IPlanetaryBody {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 1/29/2015. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public PlanetViewModel( ) {
            this.DisplayName = "P:";
            this.PropertyChanged += ( sender, args ) =>
                                    {
                                        switch( args.PropertyName ) {
                                            case "Size":
                                            case "Habitable":
                                                this.SetDisplayName( );
                                                break;
                                        }
                                    };
        }

        #region Implementation of IBaseViewModel<IPlanetaryBody>

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///-------------------------------------------------------------------------------------------------
        public IPlanetaryBody DomainObject {
            get { return this._domainObject; }
            set {
                this._domainObject = value;
                this.SetDisplayName( );
            }
        }

        /// <summary>   The domain object. </summary>
        private IPlanetaryBody _domainObject;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sets display name. </summary>
        ///
        /// <remarks>   Forest Feather, 3/23/2016. </remarks>
        ///-------------------------------------------------------------------------------------------------
        private void SetDisplayName( ) {
            this.DisplayName = string.Format( "P:{0}{1}", this.Size, this.Habitable ? "^" : "" );
        }

        #endregion

        #region Implementation of IPlanetaryBody

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the size. </summary>
        ///
        /// <value> The size. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Size"/>
        ///-------------------------------------------------------------------------------------------------
        public PlanetSize Size {
            get { return this.DomainObject.Size; }
            set {
                this.DomainObject.Size = value;
                this.OnPropertyChanged( "Size" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the diameter. </summary>
        ///
        /// <value> The diameter. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Diameter"/>
        ///-------------------------------------------------------------------------------------------------
        public double Diameter {
            get { return this.DomainObject.Diameter; }
            set {
                this.DomainObject.Diameter = value;
                this.OnPropertyChanged( "Diameter" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the gravity. </summary>
        ///
        /// <value> The gravity. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Gravity"/>
        ///-------------------------------------------------------------------------------------------------
        public double Gravity {
            get { return this.DomainObject.Gravity; }
            set {
                this.DomainObject.Gravity = value;
                this.OnPropertyChanged( "Gravity" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the lunar bodies. </summary>
        ///
        /// <value> The lunar bodies. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LunarBodies"/>
        ///-------------------------------------------------------------------------------------------------
        public IList<IPlanetaryBody> LunarBodies {
            get { return this.DomainObject.LunarBodies; }
            set {
                this.DomainObject.LunarBodies = value;
                this.OnPropertyChanged( "LunarBodies" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the planet order. </summary>
        ///
        /// <value> The planet order. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.PlanetOrder"/>
        ///-------------------------------------------------------------------------------------------------
        public int PlanetOrder {
            get { return this.DomainObject.PlanetOrder; }
            set {
                this.DomainObject.PlanetOrder = value;
                this.OnPropertyChanged( "PlanetOrder" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of moons. </summary>
        ///
        /// <value> The total number of moons. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumMoons"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumMoons {
            get { return this.DomainObject.NumMoons; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of asteroids. </summary>
        ///
        /// <value> The total number of asteroids. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumAsteroids"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumAsteroids {
            get { return this.DomainObject.NumAsteroids; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of rings. </summary>
        ///
        /// <value> The total number of rings. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumRings"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumRings {
            get { return this.DomainObject.NumRings; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the pressure. </summary>
        ///
        /// <value> The pressure. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Pressure"/>
        ///-------------------------------------------------------------------------------------------------
        public AtmosphericPressure Pressure {
            get { return this.DomainObject.Pressure; }
            set {
                this.DomainObject.Pressure = value;
                this.OnPropertyChanged( "Pressure" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the temperature. </summary>
        ///
        /// <value> The temperature. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Temperature"/>
        ///-------------------------------------------------------------------------------------------------
        public Temperature Temperature {
            get { return this.DomainObject.Temperature; }
            set {
                this.DomainObject.Temperature = value;
                this.OnPropertyChanged( "Temperature" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the toxicity. </summary>
        ///
        /// <value> The toxicity. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Toxicity"/>
        ///-------------------------------------------------------------------------------------------------
        public Toxicity Toxicity {
            get { return this.DomainObject.Toxicity; }
            set {
                this.DomainObject.Toxicity = value;
                this.OnPropertyChanged( "Toxicity" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the radiation level. </summary>
        ///
        /// <value> The radiation level. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.RadiationLevel"/>
        ///-------------------------------------------------------------------------------------------------
        public int RadiationLevel {
            get { return this.DomainObject.RadiationLevel; }
            set {
                this.DomainObject.RadiationLevel = value;
                this.OnPropertyChanged( "RadiationLevel" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets a value indicating whether this object is habitable. </summary>
        ///
        /// <value> true if habitable, false if not. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Habitable"/>
        ///-------------------------------------------------------------------------------------------------
        public bool Habitable {
            get { return this.DomainObject.Habitable; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the occupied. </summary>
        ///
        /// <value> The occupied. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Occupied"/>
        ///-------------------------------------------------------------------------------------------------
        public int Occupied {
            get { return this.DomainObject.Occupied; }
            set {
                this.DomainObject.Occupied = value;
                this.OnPropertyChanged( "Occupied" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the technology level. </summary>
        ///
        /// <value> The technology level. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.TechnologyLevel"/>
        ///-------------------------------------------------------------------------------------------------
        public TechLevel TechnologyLevel {
            get { return this.DomainObject.TechnologyLevel; }
            set {
                this.DomainObject.TechnologyLevel = value;
                this.OnPropertyChanged( "TechnologyLevel" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the liquid surface percentage. </summary>
        ///
        /// <value> The liquid surface percentage. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LiquidSurfacePercentage"/>
        ///-------------------------------------------------------------------------------------------------
        public double LiquidSurfacePercentage {
            get { return this.DomainObject.LiquidSurfacePercentage; }
            set {
                this.DomainObject.LiquidSurfacePercentage = value;
                this.OnPropertyChanged( "LiquidSurfacePercentage" );
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the axial tilt. </summary>
        ///
        /// <value> The axial tilt. </value>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.AxialTilt"/>
        ///-------------------------------------------------------------------------------------------------
        public double AxialTilt {
            get { return this.DomainObject.AxialTilt; }
            set {
                this.DomainObject.AxialTilt = value;
                this.OnPropertyChanged( "AxialTilt" );
            }
        }

        #endregion
    }
}
