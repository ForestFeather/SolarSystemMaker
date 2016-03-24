// // ==========================================================================================================
// // 
// //  File ID: SolarSystemMaker - SolarSystemLibrary - SolarSystem.cs 
// // 
// //  Last Changed By: ForestFeather - 
// //  Last Changed Date: 9:05 PM, 23/03/2016
// //  Created Date: 5:54 PM, 11/02/2015
// // 
// //  Notes:
// //  
// // ==========================================================================================================

#region Imported Namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace SolarSystemLibrary.Models {
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Solar system. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="ISolarSystem"/>
    ///-------------------------------------------------------------------------------------------------
    public class SolarSystem : ISolarSystem {
        #region Overrides of Object

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Returns a <see cref="T:System.String"/> that represents the current
        ///     <see cref="T:System.Object"/>.
        /// </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <returns>   A string that represents this object. </returns>
        ///
        /// <seealso cref="object.ToString()"/>
        ///-------------------------------------------------------------------------------------------------
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

        #region Implementation of ISolarSystem

        #region Constructors

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public SolarSystem( ) {
            this.Stars = new List<IStar>( );
            this.Planets = new List<IPlanetaryBody>( );
        }

        #endregion

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the stars. </summary>
        ///
        /// <value> The stars. </value>
        ///
        /// <seealso cref="ISolarSystem.Stars"/>
        ///-------------------------------------------------------------------------------------------------
        public IList<IStar> Stars { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the planets. </summary>
        ///
        /// <value> The planets. </value>
        ///
        /// <seealso cref="ISolarSystem.Planets"/>
        ///-------------------------------------------------------------------------------------------------
        public IList<IPlanetaryBody> Planets { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of stars. </summary>
        ///
        /// <value> The total number of stars. </value>
        ///
        /// <seealso cref="ISolarSystem.NumStars"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumStars {
            get { return this.Stars != null ? this.Stars.Count : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of planets. </summary>
        ///
        /// <value> The total number of planets. </value>
        ///
        /// <seealso cref="ISolarSystem.NumPlanets"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumPlanets {
            get { return this.Planets != null ? this.Planets.Count : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of moons. </summary>
        ///
        /// <value> The total number of moons. </value>
        ///
        /// <seealso cref="ISolarSystem.NumMoons"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumMoons {
            get { return this.Planets != null ? this.Planets.Sum( p => p.NumMoons ) : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of habitable planets. </summary>
        ///
        /// <value> The total number of habitable planets. </value>
        ///
        /// <seealso cref="ISolarSystem.NumHabitablePlanets"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumHabitablePlanets {
            get { return this.Planets != null ? this.Planets.Count( s => s.Habitable ) : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of habitable moons. </summary>
        ///
        /// <value> The total number of habitable moons. </value>
        ///
        /// <seealso cref="ISolarSystem.NumHabitableMoons"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumHabitableMoons {
            get { return this.Planets != null ? this.Planets.Sum( s => s.LunarBodies.Count( l => l.Habitable ) ) : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of habitable bodies. </summary>
        ///
        /// <value> The total number of habitable bodies. </value>
        ///
        /// <seealso cref="ISolarSystem.NumHabitableBodies"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumHabitableBodies {
            get { return this.Planets != null ? this.NumHabitablePlanets + this.NumHabitableMoons : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of solid planets. </summary>
        ///
        /// <value> The total number of solid planets. </value>
        ///
        /// <seealso cref="ISolarSystem.NumSolidPlanets"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumSolidPlanets {
            get {
                return this.Planets != null
                           ? this.Planets.Count(
                               p => p.Size > PlanetSize.AsteroidBelt && p.Size < PlanetSize.SubJovian )
                           : -1;
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of jovian planets. </summary>
        ///
        /// <value> The total number of jovian planets. </value>
        ///
        /// <seealso cref="ISolarSystem.NumJovianPlanets"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumJovianPlanets {
            get { return this.Planets != null ? this.Planets.Count( p => p.Size >= PlanetSize.SubJovian ) : -1; }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the number of asteroid belts. </summary>
        ///
        /// <value> The total number of asteroid belts. </value>
        ///
        /// <seealso cref="ISolarSystem.NumAsteroidBelts"/>
        ///-------------------------------------------------------------------------------------------------
        public int NumAsteroidBelts {
            get { return this.Planets != null ? this.Planets.Count( p => p.Size == PlanetSize.AsteroidBelt ) : -1; }
        }

        #endregion
    }
}
