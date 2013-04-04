// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - SolarSystem.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:48 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Solar system. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="ISolarSystem"/>
    ///=================================================================================================
    public class SolarSystem : ISolarSystem {
        #region Implementation of ISolarSystem

        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///=================================================================================================
        public SolarSystem( ) {
            this.Stars = new List<IStar>( );
            this.Planets = new List<IPlanetaryBody>( );
        }

        #endregion

        ///=================================================================================================
        /// <summary>   Gets or sets the stars. </summary>
        ///
        /// <seealso cref="ISolarSystem.Stars"/>
        ///
        /// ### <value> The stars. </value>
        ///=================================================================================================
        public IList<IStar> Stars { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planets. </summary>
        ///
        /// <seealso cref="ISolarSystem.Planets"/>
        ///
        /// ### <value> The planets. </value>
        ///=================================================================================================
        public IList<IPlanetaryBody> Planets { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of stars. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumStars"/>
        ///
        /// ### <value> The total number of stars. </value>
        ///=================================================================================================
        public int NumStars { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of planets. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumPlanets"/>
        ///
        /// ### <value> The total number of planets. </value>
        ///=================================================================================================
        public int NumPlanets { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of moons. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumMoons"/>
        ///
        /// ### <value> The total number of moons. </value>
        ///=================================================================================================
        public int NumMoons { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of habitable planets. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumHabitablePlanets"/>
        ///
        /// ### <value> The total number of habitable planets. </value>
        ///=================================================================================================
        public int NumHabitablePlanets { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of habitable moons. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumHabitableMoons"/>
        ///
        /// ### <value> The total number of habitable moons. </value>
        ///=================================================================================================
        public int NumHabitableMoons { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of habitable bodies. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumHabitableBodies"/>
        ///
        /// ### <value> The total number of habitable bodies. </value>
        ///=================================================================================================
        public int NumHabitableBodies { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of solid planets. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumSolidPlanets"/>
        ///
        /// ### <value> The total number of solid planets. </value>
        ///=================================================================================================
        public int NumSolidPlanets { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of jovian planets. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumJovianPlanets"/>
        ///
        /// ### <value> The total number of jovian planets. </value>
        ///=================================================================================================
        public int NumJovianPlanets { get; private set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the number of asteroid belts. </summary>
        ///
        /// <seealso cref="ISolarSystem.NumAsteroidBelts"/>
        ///
        /// ### <value> The total number of asteroid belts. </value>
        ///=================================================================================================
        public int NumAsteroidBelts { get; private set; }

        #endregion

        #region Overrides of Object

        ///=================================================================================================
        /// <summary>
        ///     Returns a <see cref="T:System.String"/> that represents the current
        ///     <see cref="T:System.Object"/>.
        /// </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="object.ToString()"/>
        ///
        /// ### <returns>
        ///     A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        ///=================================================================================================
        public override string ToString( ) {
            return
                string.Format(
                    "Number of Stars: {0}\t\tNumber of Planets: {1}\r\n\r\n{2}\r\n\r\n{3}",
                    this.Stars.Count,
                    this.Planets.Count,
                    this.Stars.Aggregate( "", ( current, star ) => current + star.ToString( ) ),
                    this.Planets.Aggregate( "", ( current, planet ) => current + planet.ToString( ) ) );
        }

        #endregion
    }
}
