// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - SolarSystemViewModel.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 11:24 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemMaker.ViewModels {
    ///=================================================================================================
    /// <summary>   Solar system view model. </summary>
    ///
    /// <remarks>   Cdo, 4/1/2013. </remarks>
    ///
    /// <seealso cref="SolarSystemMaker.ViewModels.BaseViewModel"/>
    /// <seealso cref="SolarSystemMaker.ViewModels.IBaseViewModel<SolarSystemLibrary.Models.ISolarSystem>"/>
    /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem"/>
    ///=================================================================================================
    public class SolarSystemViewModel : BaseViewModel, IBaseViewModel<ISolarSystem>, ISolarSystem {
        #region Implementation of IBaseViewModel<ISolarSystem>

        ///=================================================================================================
        /// <summary>   Gets or sets the domain object. </summary>
        ///
        /// <value> The domain object. </value>
        ///=================================================================================================
        public ISolarSystem DomainObject { get; set; }

        #endregion

        #region Implementation of ISolarSystem

        ///=================================================================================================
        /// <summary>   Gets or sets the stars. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.Stars"/>
        ///
        /// ### <value> The stars. </value>
        ///=================================================================================================
        public IList<IStar> Stars {
            get { return this.DomainObject.Stars; }
            set {
                this.DomainObject.Stars = value;
                this.OnPropertyChanged( "Stars" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets or sets the planets. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.Planets"/>
        ///
        /// ### <value> The planets. </value>
        ///=================================================================================================
        public IList<IPlanetaryBody> Planets {
            get { return this.DomainObject.Planets; }
            set {
                this.DomainObject.Planets = value;
                this.OnPropertyChanged( "Planets" );
            }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of stars. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumStars"/>
        ///
        /// ### <value> The total number of stars. </value>
        ///=================================================================================================
        public int NumStars {
            get { return this.DomainObject.NumStars; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of planets. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumPlanets"/>
        ///
        /// ### <value> The total number of planets. </value>
        ///=================================================================================================
        public int NumPlanets {
            get { return this.DomainObject.NumPlanets; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of moons. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumMoons"/>
        ///
        /// ### <value> The total number of moons. </value>
        ///=================================================================================================
        public int NumMoons {
            get { return this.DomainObject.NumMoons; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable planets. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumHabitablePlanets"/>
        ///
        /// ### <value> The total number of habitable planets. </value>
        ///=================================================================================================
        public int NumHabitablePlanets {
            get { return this.DomainObject.NumHabitablePlanets; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable moons. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumHabitableMoons"/>
        ///
        /// ### <value> The total number of habitable moons. </value>
        ///=================================================================================================
        public int NumHabitableMoons {
            get { return this.DomainObject.NumHabitableMoons; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of habitable bodies. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumHabitableBodies"/>
        ///
        /// ### <value> The total number of habitable bodies. </value>
        ///=================================================================================================
        public int NumHabitableBodies {
            get { return this.DomainObject.NumHabitableBodies; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of solid planets. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumSolidPlanets"/>
        ///
        /// ### <value> The total number of solid planets. </value>
        ///=================================================================================================
        public int NumSolidPlanets {
            get { return this.DomainObject.NumSolidPlanets; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of jovian planets. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumJovianPlanets"/>
        ///
        /// ### <value> The total number of jovian planets. </value>
        ///=================================================================================================
        public int NumJovianPlanets {
            get { return this.DomainObject.NumJovianPlanets; }
        }

        ///=================================================================================================
        /// <summary>   Gets the number of asteroid belts. </summary>
        ///
        /// <seealso cref="SolarSystemLibrary.Models.ISolarSystem.NumAsteroidBelts"/>
        ///
        /// ### <value> The total number of asteroid belts. </value>
        ///=================================================================================================
        public int NumAsteroidBelts {
            get { return this.DomainObject.NumAsteroidBelts; }
        }

        #endregion
    }
}
