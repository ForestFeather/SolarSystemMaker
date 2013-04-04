// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - LunarBodyViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 11:11 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using SolarSystemLibrary;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemMaker.ViewModels {

    ///=================================================================================================
    /// <summary>   Lunar body view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel<SolarSystemLibrary.Models.IPlanetaryBody>"/>
    /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody"/>
    ///=================================================================================================
    public class LunarBodyViewModel : BaseViewModel, IBaseViewModel<IPlanetaryBody>, IPlanetaryBody {
        public LunarBodyViewModel( ) {
            DisplayName = "   Lunar Body";
        }

        #region Implementation of IBaseViewModel<IPlanetaryBody>

        ///=================================================================================================
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///=================================================================================================
        public IPlanetaryBody DomainObject { get; set; }

        #endregion

        #region Implementation of IPlanetaryBody

        ///=================================================================================================
        /// <summary>   Gets or sets the size. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Size"/>
        ///
        /// ### <value> The size. </value>
        ///=================================================================================================
        public PlanetSize Size {
            get { return this.DomainObject.Size; }
            set {
                this.DomainObject.Size = value;
                this.OnPropertyChanged( "Size" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the diameter. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Diameter"/>
        ///
        /// ### <value> The diameter. </value>
        ///=================================================================================================
        public double Diameter {
            get { return this.DomainObject.Diameter; }
            set {
                this.DomainObject.Diameter = value;
                this.OnPropertyChanged( "Diameter" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the gravity. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Gravity"/>
        ///
        /// ### <value> The gravity. </value>
        ///=================================================================================================
        public double Gravity {
            get { return this.DomainObject.Gravity; }
            set {
                this.DomainObject.Gravity = value;
                this.OnPropertyChanged( "Gravity" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar bodies. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LunarBodies"/>
        ///
        /// ### <value> The lunar bodies. </value>
        ///=================================================================================================
        public IList<IPlanetaryBody> LunarBodies {
            get { return this.DomainObject.LunarBodies; }
            set {
                this.DomainObject.LunarBodies = value;
                this.OnPropertyChanged( "LunarBodies" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the planet order. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.PlanetOrder"/>
        ///
        /// ### <value> The planet order. </value>
        ///=================================================================================================
        public int PlanetOrder {
            get { return this.DomainObject.PlanetOrder; }
            set {
                this.DomainObject.PlanetOrder = value;
                this.OnPropertyChanged( "PlanetOrder" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of moons. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumMoons"/>
        ///
        /// ### <value> The total number of moons. </value>
        ///=================================================================================================
        public int NumMoons {
            get { return this.DomainObject.NumMoons; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of asteroids. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumAsteroids"/>
        ///
        /// ### <value> The total number of asteroids. </value>
        ///=================================================================================================
        public int NumAsteroids {
            get { return this.DomainObject.NumAsteroids; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of rings. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.NumRings"/>
        ///
        /// ### <value> The total number of rings. </value>
        ///=================================================================================================
        public int NumRings {
            get { return this.DomainObject.NumRings; }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the pressure. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Pressure"/>
        ///
        /// ### <value> The pressure. </value>
        ///=================================================================================================
        public AtmosphericPressure Pressure {
            get { return this.DomainObject.Pressure; }
            set {
                this.DomainObject.Pressure = value;
                this.OnPropertyChanged( "Pressure" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the temperature. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Temperature"/>
        ///
        /// ### <value> The temperature. </value>
        ///=================================================================================================
        public Temperature Temperature {
            get { return this.DomainObject.Temperature; }
            set {
                this.DomainObject.Temperature = value;
                this.OnPropertyChanged( "Temperature" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the toxicity. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Toxicity"/>
        ///
        /// ### <value> The toxicity. </value>
        ///=================================================================================================
        public Toxicity Toxicity {
            get { return this.DomainObject.Toxicity; }
            set {
                this.DomainObject.Toxicity = value;
                this.OnPropertyChanged( "Toxicity" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the radiation level. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.RadiationLevel"/>
        ///
        /// ### <value> The radiation level. </value>
        ///=================================================================================================
        public int RadiationLevel {
            get { return this.DomainObject.RadiationLevel; }
            set {
                this.DomainObject.RadiationLevel = value;
                this.OnPropertyChanged( "RadiationLevel" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets a value indicating whether this object is habitable. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Habitable"/>
        ///
        /// ### <value> true if habitable, false if not. </value>
        ///=================================================================================================
        public bool Habitable {
            get { return this.DomainObject.Habitable; }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the occupied. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.Occupied"/>
        ///
        /// ### <value> The occupied. </value>
        ///=================================================================================================
        public int Occupied {
            get { return this.DomainObject.Occupied; }
            set {
                this.DomainObject.Occupied = value;
                this.OnPropertyChanged( "Occupied" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the technology level. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.TechnologyLevel"/>
        ///
        /// ### <value> The technology level. </value>
        ///=================================================================================================
        public TechLevel TechnologyLevel {
            get { return this.DomainObject.TechnologyLevel; }
            set {
                this.DomainObject.TechnologyLevel = value;
                this.OnPropertyChanged( "TechnologyLevel" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the liquid surface percentage. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.LiquidSurfacePercentage"/>
        ///
        /// ### <value> The liquid surface percentage. </value>
        ///=================================================================================================
        public double LiquidSurfacePercentage {
            get { return this.DomainObject.LiquidSurfacePercentage; }
            set {
                this.DomainObject.LiquidSurfacePercentage = value;
                this.OnPropertyChanged( "LiquidSurfacePercentage" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the axial tilt. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.IPlanetaryBody.AxialTilt"/>
        ///
        /// ### <value> The axial tilt. </value>
        ///=================================================================================================
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
