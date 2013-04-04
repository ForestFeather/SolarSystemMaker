// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - ISystemGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 7:07 AM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary.Models.interfaces;

#endregion

namespace SolarSystemLibrary.support.interfaces {
    ///=================================================================================================
    /// <summary>   Interface for system generator. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface ISystemGenerator {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the solar generator. </summary>
        ///
        /// <value> The solar generator. </value>
        ///=================================================================================================
        ISolarGenerator SolarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the planetary generator. </summary>
        ///
        /// <value> The planetary generator. </value>
        ///=================================================================================================
        IPlanetaryGenerator PlanetaryGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the lunar generator. </summary>
        ///
        /// <value> The lunar generator. </value>
        ///=================================================================================================
        ILunarGenerator LunarGenerator { get; set; }

        ///=================================================================================================
        /// <summary>   Gets a value indicating whether the initialized. </summary>
        ///
        /// <value> true if initialized, false if not. </value>
        ///=================================================================================================
        bool Initialized { get; }

        #endregion

        #region Members

        ///=================================================================================================
        /// <summary>   Initializes this object. </summary>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///=================================================================================================
        bool Initialize( );

        ///=================================================================================================
        /// <summary>   Generates a solar system. </summary>
        ///
        /// <param name="numStars">                 (optional) number of stars. </param>
        /// <param name="numPlanets">               (optional) number of planets. </param>
        /// <param name="firstHabitablePlanet">     (optional) the first habitable planet. </param>
        /// <param name="numHabitablePlanets">      (optional) number of habitable planets. </param>
        /// <param name="numGoldilocksZonePlanets"> (optional) number of goldilocks zone planets. </param>
        /// <param name="solarGenerator">           The solar generator. </param>
        /// <param name="planetaryGenerator">       The planetary generator. </param>
        /// <param name="lunarGenerator">           The lunar generator. </param>
        ///
        /// <returns>   The solar system. </returns>
        ///=================================================================================================
        ISolarSystem GenerateSolarSystem( int numStars = -1,
                                          int numPlanets = -1,
                                          int firstHabitablePlanet = -1,
                                          int numHabitablePlanets = -1,
                                          int numGoldilocksZonePlanets = -1,
                                          ISolarGenerator solarGenerator = null,
                                          IPlanetaryGenerator planetaryGenerator = null,
                                          ILunarGenerator lunarGenerator = null );

        #endregion
    }
}
