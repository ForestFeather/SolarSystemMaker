// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - ILunarGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 7:04 AM, 28/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Interface for lunar generator. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface ILunarGenerator {
        #region Properties

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
        /// <summary>   Generates a lunar body. </summary>
        ///
        /// <param name="lunarBodySize">        Size of the lunar body. </param>
        /// <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// <param name="parentPlanet">         The parent planet. </param>
        ///
        /// <returns>   The lunar body. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateLunarBody( PlanetSize lunarBodySize = PlanetSize.NullSize,
                                          int parentPlanetOrder = -1,
                                          IPlanetaryBody parentPlanet = null );

        ///=================================================================================================
        /// <summary>   Generates the rings. </summary>
        ///
        /// <param name="parentPlanet"> The parent planet. </param>
        ///
        /// <returns>   The rings. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateRings( IPlanetaryBody parentPlanet = null );

        ///=================================================================================================
        /// <summary>   Generates an asteroid. </summary>
        ///
        /// <param name="parentPlanet"> The parent planet. </param>
        ///
        /// <returns>   The asteroid. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateAsteroid( IPlanetaryBody parentPlanet = null );

        ///=================================================================================================
        /// <summary>   Generates a moon. </summary>
        ///
        /// <param name="moonSize">             Size of the moon. </param>
        /// <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// <param name="parentPlanet">         The parent planet. </param>
        ///
        /// <returns>   The moon. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateMoon( PlanetSize moonSize = PlanetSize.NullSize,
                                     int parentPlanetOrder = -1,
                                     IPlanetaryBody parentPlanet = null );

        ///=================================================================================================
        /// <summary>   Generates a habitable moon. </summary>
        ///
        /// <param name="moonSize">             Size of the moon. </param>
        /// <param name="parentPlanetOrder">    (optional) the parent planet order. </param>
        /// <param name="parentPlanet">         The parent planet. </param>
        ///
        /// <returns>   The habitable moon. </returns>
        ///=================================================================================================
        IPlanetaryBody GenerateHabitableMoon( PlanetSize moonSize = PlanetSize.NullSize,
                                              int parentPlanetOrder = -1,
                                              IPlanetaryBody parentPlanet = null );

        #endregion
    }
}
