// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemLibrary - ISolarGenerator.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 9:45 AM, 01/04/2013
// 
//  Notes:
//  
// ==========================================================================================================

#region Imported Namespaces

using SolarSystemLibrary.Models;

#endregion

namespace SolarSystemLibrary {
    ///=================================================================================================
    /// <summary>   Interface for solar generator. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface ISolarGenerator {
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
        /// <summary>   Generates a solar body. </summary>
        ///
        /// <param name="category">     (optional) the category. </param>
        /// <param name="mainSequence"> (optional) the main sequence. </param>
        /// <param name="parentSystem"> (optional) the parent system. </param>
        ///
        /// <returns>   The solar body. </returns>
        ///=================================================================================================
        IStar GenerateSolarBody( StarCategory category = StarCategory.NullCategory,
                                 bool? mainSequence = null,
                                 ISolarSystem parentSystem = null );

        ///=================================================================================================
        /// <summary>   Generates a main sequence star. </summary>
        ///
        /// <param name="category">     (optional) the category. </param>
        /// <param name="parentSystem"> (optional) the parent system. </param>
        ///
        /// <returns>   The main sequence star. </returns>
        ///=================================================================================================
        IStar GenerateMainSequenceStar( StarCategory category = StarCategory.NullCategory,
                                        ISolarSystem parentSystem = null );

        ///=================================================================================================
        /// <summary>   Generates a non main sequence star. </summary>
        ///
        /// <param name="category">     (optional) the category. </param>
        /// <param name="parentSystem"> (optional) the parent system. </param>
        ///
        /// <returns>   The non main sequence star. </returns>
        ///=================================================================================================
        IStar GenerateNonMainSequenceStar( StarCategory category = StarCategory.NullCategory,
                                           ISolarSystem parentSystem = null );

        ///=================================================================================================
        /// <summary>   Generates a life supporting star. </summary>
        ///
        /// <param name="category">     (optional) the category. </param>
        /// <param name="mainSequence"> (optional) the main sequence. </param>
        /// <param name="parentSystem"> (optional) the parent system. </param>
        ///
        /// <returns>   The life supporting star. </returns>
        ///=================================================================================================
        IStar GenerateLifeSupportingStar( StarCategory category = StarCategory.NullCategory,
                                          bool? mainSequence = null,
                                          ISolarSystem parentSystem = null );

        #endregion
    }
}
