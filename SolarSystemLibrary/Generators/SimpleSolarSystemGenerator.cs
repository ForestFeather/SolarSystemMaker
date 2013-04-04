// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - SimpleSolarSystemGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 12:22 PM, 29/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using System;
using System.Collections.Generic;
using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary.Generators {
    ///=================================================================================================
    /// <summary>   Simple solar system generator. </summary>
    ///
    /// <remarks>   Cdo, 3/29/2013. </remarks>
    ///
    /// <seealso cref="ISystemGenerator"/>
    ///=================================================================================================
    public class SimpleSolarSystemGenerator : ISystemGenerator {
        #region Constructors

        ///=================================================================================================
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///=================================================================================================
        public SimpleSolarSystemGenerator( ) {
            this.Initialized = false;
        }

        ///=================================================================================================
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <param name="solarGenerator">   The solar generator. </param>
        /// <param name="planetGenerator">  The planet generator. </param>
        /// <param name="lunarGenerator">   The lunar generator. </param>
        ///=================================================================================================
        public SimpleSolarSystemGenerator( ISolarGenerator solarGenerator,
                                           IPlanetaryGenerator planetGenerator,
                                           ILunarGenerator lunarGenerator ) {
            this.Initialized = false;
            this.SolarGenerator = solarGenerator;
            this.PlanetaryGenerator = planetGenerator;
            this.LunarGenerator = lunarGenerator;
        }

        #endregion

        #region Implementation of ISystemGenerator

        ///=================================================================================================
        /// <summary>   Gets or sets the solar generator. </summary>
        ///
        /// <seealso cref="ISystemGenerator.SolarGenerator"/>
        ///=================================================================================================
        public ISolarGenerator SolarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planetary generator. </summary>
        ///
        /// <seealso cref="ISystemGenerator.PlanetaryGenerator"/>
        ///=================================================================================================
        public IPlanetaryGenerator PlanetaryGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar generator. </summary>
        ///
        /// <seealso cref="ISystemGenerator.LunarGenerator"/>
        ///=================================================================================================
        public ILunarGenerator LunarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the initialized. </summary>
        ///
        /// <seealso cref="ISystemGenerator.Initialized"/>
        ///=================================================================================================
        public bool Initialized { get; private set; }

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="ISystemGenerator.Initialize"/>
        ///=================================================================================================
        public bool Initialize( ) {
            this.Dice = new DiceRoller( );
            return this.PlanetaryGenerator != null && this.SolarGenerator != null && this.LunarGenerator != null;
        }

        ///=================================================================================================
        /// <summary>   Generates a solar system. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <seealso cref="SolarSystemMaker.ISystemGenerator.GenerateSolarSystem(optional int,optional int,optional int,optional int,optional int,optional ISolarGenerator,optional IPlanetaryGenerator,optional ILunarGenerator)"/>
        ///
        /// ### <param name="numStars">                 (optional) number of stars. </param>
        /// ### <param name="numPlanets">               (optional) number of planets. </param>
        /// ### <param name="firstHabitablePlanet">     (optional) the first habitable planet. </param>
        /// ### <param name="numHabitablePlanets">      (optional) number of habitable planets. </param>
        /// ### <param name="numGoldilocksZonePlanets"> (optional) number of goldilocks zone planets.
        /// </param>
        /// ### <param name="solarGenerator">           The solar generator. </param>
        /// ### <param name="planetaryGenerator">       The planetary generator. </param>
        /// ### <param name="lunarGenerator">           The lunar generator. </param>
        ///=================================================================================================
        public ISolarSystem GenerateSolarSystem( int numStars = -1,
                                                 int numPlanets = -1,
                                                 int firstHabitablePlanet = -1,
                                                 int numHabitablePlanets = -1,
                                                 int numGoldilocksZonePlanets = -1,
                                                 ISolarGenerator solarGenerator = null,
                                                 IPlanetaryGenerator planetaryGenerator = null,
                                                 ILunarGenerator lunarGenerator = null ) {
            var localSolar = solarGenerator ?? this.SolarGenerator;
            var localPlanetary = planetaryGenerator ?? this.PlanetaryGenerator;
            var localLunar = lunarGenerator ?? this.LunarGenerator;

            ISolarSystem system = new SolarSystem( );

            // Get our counts of how much/what to generate
            var stars = numStars > 0 ? numStars : this.RollRandomStarCount( );
            var planets = numPlanets > 0 ? numPlanets : this.Dice.Roll( 3, 6 );
            var needPlanets = ( numHabitablePlanets > -1 ) || ( numGoldilocksZonePlanets > 0 );
            var innermostTempLevel = firstHabitablePlanet > 0
                                         ? Math.Min( firstHabitablePlanet - 1, 6 )
                                         : this.Dice.d6( );
            var havePlanets = false;
            int habitablePlanets;
            var minHabitablePlanets = numHabitablePlanets > 0 ? numHabitablePlanets : 0;
            var count = 0;

            // Create our stars
            do {
                system.Stars = new List<IStar>( );
                for ( var i = 0; i < stars; i++ ) {
                    var solarBody = localSolar.GenerateSolarBody( );
                    system.Stars.Add( solarBody );
                    if ( solarBody.Category != StarCategory.Hypergiant &&
                         solarBody.Category != StarCategory.Dwarf ) {
                        havePlanets = true;
                    }
                }
            } while ( !havePlanets && needPlanets && count++ < 100 );

            if ( !havePlanets ) {
                return system;
            }

            // Create our planets (moons generated within)
            count = 0;
            do {
                var currentTemplevel = innermostTempLevel;
                habitablePlanets = 0;
                var currentGoldilocksCount = 0;
                system.Planets = new List<IPlanetaryBody>( );

                for ( var i = 0; i < planets; i++ ) {
                    var planet = localPlanetary.GeneratePlanetaryBody(
                        planetOrder: currentTemplevel, lunarGenerator: localLunar );
                    system.Planets.Add( planet );
                    if ( planet.Habitable ) {
                        habitablePlanets++;
                    }

                    if ( ( currentTemplevel == 0 &&
                         currentGoldilocksCount < numGoldilocksZonePlanets ) ) {
                        currentGoldilocksCount++;
                    } else {
                        currentTemplevel--;
                    }
                }
            } while (habitablePlanets < minHabitablePlanets && count++ < 100);

            // All done, return
            return system;
        }

        #region Members

        ///=================================================================================================
        /// <summary>   Gets the roll random star count. </summary>
        ///
        /// <remarks>   Cdo, 3/29/2013. </remarks>
        ///
        /// <returns>   . </returns>
        ///=================================================================================================
        protected int RollRandomStarCount( ) {
            int stars;
            var roll = this.Dice.d20( );
            switch ( roll ) {
                case 20:
                    stars = 4;
                    break;
                case 19:
                    stars = 3;
                    break;
                case 18:
                case 17:
                    stars = 2;
                    break;
                default:
                    stars = 1;
                    break;
            }
            return stars;
        }

        #endregion

        #endregion

        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the dice. </summary>
        ///
        /// <value> The dice. </value>
        ///=================================================================================================
        protected DiceRoller Dice { get; set; }

        #endregion
    }
}
