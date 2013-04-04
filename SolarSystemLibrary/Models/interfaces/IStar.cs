// ==========================================================================================================
// 
//  File ID: SolarSystemMaker - SolarSystemMaker - IStar.cs 
// 
//  Copyright 2011-2012
//  WR Medical Electronics Company
// 
//  Last Changed By: cdo - Collin D. O'Connor
//  Last Changed Date: 2:31 PM, 27/03/2013
// 
//  Notes:
//  
// ==========================================================================================================

namespace SolarSystemLibrary.Models {
    ///=================================================================================================
    /// <summary>   Interface for star. </summary>
    ///
    /// <remarks>   Cdo, 3/27/2013. </remarks>
    ///=================================================================================================
    public interface IStar {
        #region Properties

        ///=================================================================================================
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <value> The category. </value>
        ///=================================================================================================
        StarCategory Category { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets a value indicating whether the main sequence star. </summary>
        ///
        /// <value> true if main sequence star, false if not. </value>
        ///=================================================================================================
        bool MainSequenceStar { get; set; }

        ///=================================================================================================
        /// <summary>   Gets or sets the solar mass. </summary>
        ///
        /// <value> The solar mass. </value>
        ///=================================================================================================
        double SolarMass { get; set; }

        #endregion
    }
}
